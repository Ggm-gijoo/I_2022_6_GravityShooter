using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    private LineRenderer hookLine;
    private float ammunition = 3f;

    public bool IsHookOn { private set; get; } = false;
    public bool IsUsingHook { private set; get; } = false;
    public bool IsReload { private set; get; } = false;

    private void Start()
    {
        hookLine = hook.GetComponent<LineRenderer>();
        hookLine.SetPosition(0, Vector3.zero);
        hookLine.SetPosition(1, Vector3.zero);
        hookLine.startWidth = 0.05f;
        hookLine.endWidth = 0.05f;
    }

    private void Update()
    {
        Fire();
        HookShot();
    }

    public void Fire()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (!IsHookOn && ammunition > 0)
            {
                GameObject bullet = Instantiate(bulletPrefab, firePos.position, cameraPos.rotation);
                bullet.transform.forward = cameraPos.forward + Vector3.down * 2f * Time.deltaTime;
                bullet.SendMessage("OnMove");
                ammunition--;
            }
            else if (!IsHookOn && ammunition <= 0 && !IsReload)
            {
                StartCoroutine(Reload());
            }
            else if(!IsUsingHook)
            {
                IsUsingHook = true;
                RaycastHit hitInfo;
                if(Physics.Raycast(firePos.position, cameraPos.forward, out hitInfo, 10f))
                {
                    GameObject hookClone = Instantiate(hook,hitInfo.point,firePos.rotation);

                    hookLine.SetPosition(0, firePos.position);
                    hookLine.SetPosition(1, hookClone.transform.position);

                    playerPos.DOMove(hitInfo.point, 1f);
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
        Debug.Log($"�������� . . . �Ѿ� ���� {ammunition}");
        IsReload = true;
        yield return new WaitForSeconds(3f - ammunition);
        ammunition = 3f;
        Debug.Log($"������ �Ϸ�! �Ѿ� ���� {ammunition}");
        IsReload = false;
    }

    public void HookShot()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            IsHookOn = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            IsHookOn = false;
        }
    }
}
