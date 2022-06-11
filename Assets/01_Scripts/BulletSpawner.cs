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
    private GameObject BulletPrefab;

    public void Fire()
    {
        Instantiate(BulletPrefab, firePos.position, cameraPos.rotation);
        Debug.DrawRay(firePos.position, cameraPos.forward, Color.cyan, 1000f);
    }
}
