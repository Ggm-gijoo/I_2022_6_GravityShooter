using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    private float timer = 0f;
    private float moveSpeed = 15f;
    void Start()
    {
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        while (timer < 5f)
        {
            timer += Time.deltaTime;
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime + Vector3.down * 2f * Time.deltaTime);
            yield return null;
        }
        timer = 0f;
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerController>().CurrHp -= 10f;
            Destroy(gameObject);
        }
    }
}
