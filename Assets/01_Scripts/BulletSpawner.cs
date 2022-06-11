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
    private GameObject bulletPrefab;

    public void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePos.position, cameraPos.rotation);
        bullet.transform.forward = cameraPos.forward + Vector3.down * 2f * Time.deltaTime;
        bullet.SendMessage("OnMove");
        Debug.DrawRay(firePos.position, cameraPos.forward, Color.cyan, 1000f);
    }
}