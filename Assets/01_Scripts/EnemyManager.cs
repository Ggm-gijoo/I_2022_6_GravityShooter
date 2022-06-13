using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public bool IsInhaled = false;
    public float Hp = 50f;

    private static EnemyManager instance;

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
            yield return new WaitForSeconds(1f);
            Hp -= 10f;
            Debug.Log(Hp);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "BlackHole" && !IsInhaled)
        {
            Debug.Log("¿∏æ«");
            IsInhaled = true;
            StartCoroutine(enemyInhaled());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "BlackHole" && IsInhaled)
        {
            Debug.Log("≈ª√‚!");
            IsInhaled = false;
            StopCoroutine(enemyInhaled());
        }
    }
}
