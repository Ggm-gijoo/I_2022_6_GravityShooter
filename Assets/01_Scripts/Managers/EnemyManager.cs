using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public bool IsInhaled = false;
    public bool IsStopped = false;
    public float Hp = 50f;

    private static EnemyManager instance;

    private void Update()
    {
        if(Hp <= 0)
        {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    public static EnemyManager Instance()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<EnemyManager>();
            if (instance == null)
            {
                GameObject container = new GameObject("EnemyManager");
                instance = container.AddComponent<EnemyManager>();
            }
        }
        return instance;
    }


    private IEnumerator enemyInhaled()
    {
        while (Hp > 0 && IsInhaled)
        {
            yield return new WaitForSeconds(0.7f);
            gameObject.GetComponent<AudioSource>().Play();
            Hp -= 10f;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "BlackHole" && !IsInhaled)
        {
            IsInhaled = true;
            StartCoroutine(enemyInhaled());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "BlackHole" && IsInhaled)
        {
            StopCoroutine(enemyInhaled());
            IsInhaled = false;
        }
    }
}
