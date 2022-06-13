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

    private bool isHookOn = false;

    private void Update()
    {
        Fire();
        HookShot();
    }

    public void Fire()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (!isHookOn)
            {
                GameObject bullet = Instantiate(bulletPrefab, firePos.position, cameraPos.rotation);
                bullet.transform.forward = cameraPos.forward + Vector3.down * 2f * Time.deltaTime;
                bullet.SendMessage("OnMove");
                Debug.DrawRay(firePos.position, cameraPos.forward, Color.cyan, 1000f);
            }
            else
            {
                RaycastHit hitInfo;
                Debug.DrawRay(firePos.position, cameraPos.forward, Color.red, 1000f);
                if(Physics.Raycast(firePos.position, cameraPos.forward, out hitInfo, 20f))
                {
                    playerPos.position = hitInfo.point;
                }
                Debug.Log(hitInfo);
            }
        }
    }

    public void HookShot()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            isHookOn = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isHookOn = false;
        }
    }

    private IEnumerator MoveToHook()
    {
        yield return null;
    }
}
