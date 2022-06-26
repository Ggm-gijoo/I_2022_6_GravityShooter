using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform firePos;
    [SerializeField]
    private Transform cameraPos;
    [SerializeField]
    private Transform playerPos;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private GameObject hook;
    [SerializeField]
    private GameObject reloadTextObj;
    [SerializeField]
    private GameObject[] bulletIcons;

    private Text reloadText;
    private LineRenderer hookLine;
    private AudioSource[] audioSources;
    private int ammunition = 3;
    private int reloadAmm = 3;

    public bool IsHookOn { private set; get; } = false;
    public bool IsUsingHook { private set; get; } = false;
    public bool IsReload { private set; get; } = false;

    private void Awake()
    {
        reloadTextObj.SetActive(false);
        reloadText = reloadTextObj.GetComponent<Text>();
        audioSources = GetComponents<AudioSource>();
    }

    private void Update()
    {
        if (Time.timeScale != 0)
        {
            Fire();
            HookShot();
        }
    }

    public void Fire()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (!IsHookOn && ammunition > 0 && !IsReload)
            {
                audioSources[0].Play();
                GameObject bullet = Instantiate(bulletPrefab, firePos.position, cameraPos.rotation);
                bullet.transform.forward = cameraPos.forward;
                bullet.SendMessage("OnMove");
                bulletIcons[ammunition - 1].GetComponent<Image>().color = Color.black;
                ammunition--;
                reloadAmm--;
            }
            else if (!IsHookOn && ammunition <= 0 && !IsReload)
            {
                StartCoroutine(Reload());
            }
            else if(IsHookOn &&!IsUsingHook)
            {
                IsUsingHook = true;
                RaycastHit hitInfo;
                if(Physics.Raycast(firePos.position, cameraPos.forward, out hitInfo, 10f))
                {
                    GameObject hookClone = Instantiate(hook,hitInfo.point,firePos.rotation);

                    hookLine = hookClone.GetComponent<LineRenderer>();

                    hookLine.startWidth = 0.05f;
                    hookLine.endWidth = 0.05f;

                    hookLine.SetPosition(0, firePos.position);
                    hookLine.SetPosition(1, hookClone.transform.position);

                    playerPos.DOMove(hitInfo.point, 0.5f);
                    StartCoroutine(DestroyHook(hookClone));
                }
                Debug.Log(hitInfo);
                IsUsingHook = false;
            }
        }

        if(Input.GetKeyDown(KeyCode.R) && !IsReload)
        {
            StartCoroutine(Reload());
        }
    }

    public IEnumerator Reload()
    {
        reloadTextObj.SetActive(true);
        IsReload = true;
        for(int i = 0; i < 3 - reloadAmm; i++)
        {
            yield return new WaitForSeconds(0.7f);
            audioSources[1].Play();
            reloadText.text += " .";
            ammunition += 1;
            bulletIcons[ammunition-1].GetComponent<Image>().color = Color.cyan;
        }
        reloadAmm = 3;
        yield return new WaitForSeconds(0.1f);
        reloadText.text = $"재장전 완료!";
        IsReload = false;
        yield return new WaitForSeconds(0.5f);
        reloadText.text = "재장전중";
        reloadTextObj.SetActive(false);
    }

    public IEnumerator DestroyHook(GameObject hook)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(hook);
        hookLine.SetPosition(0, Vector3.zero);
        hookLine.SetPosition(1, Vector3.zero);
    }

    public void HookShot()
    {
        if (Input.GetKey(KeyCode.LeftShift)) IsHookOn = true;
        else IsHookOn = false;
    }
}
