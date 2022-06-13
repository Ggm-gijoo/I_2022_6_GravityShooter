using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public bool IsHookOn { private set; get; } = false;
    public bool IsUsingHook { private set; get; } = false;

    private void Update()
    {
        Fire();
        HookShot();
    }

    public void Fire()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (!IsHookOn)
            {
                GameObject bullet = Instantiate(bulletPrefab, firePos.position, cameraPos.rotation);
                bullet.transform.forward = cameraPos.forward + Vector3.down * 2f * Time.deltaTime;
                bullet.SendMessage("OnMove");
                Debug.DrawRay(firePos.position, cameraPos.forward, Color.cyan, 1000f);
            }
            else if(!IsUsingHook)
            {
                IsUsingHook = true;
                RaycastHit hitInfo;
                Debug.DrawRay(firePos.position, cameraPos.forward, Color.red, 1000f);
                if(Physics.Raycast(firePos.position, cameraPos.forward, out hitInfo, 10f))
                {
                    StartCoroutine(MoveToHook(playerPos, hitInfo.point));
                }
                Debug.Log(hitInfo);
            }
        }
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

    private IEnumerator MoveToHook(Transform playerPos,Vector3 hitPoint)
    {
        while (Vector3.Distance(hitPoint,playerPos.position) > 1f  && IsUsingHook)
        {
            Debug.Log(Vector3.Distance(hitPoint, playerPos.position));
            Vector3 moveDir = hitPoint - playerPos.position;
            playerPos.Translate(moveDir * 3f * Time.deltaTime);
            yield return null;
        }
        IsUsingHook = false;
    }
}
