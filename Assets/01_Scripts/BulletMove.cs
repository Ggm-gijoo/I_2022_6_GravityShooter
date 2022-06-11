using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    private float moveSpeed = 10f;

    private void OnMove()
    {
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        while (true)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            Debug.Log($"�浹ü : {other.name}");
            Collider[] colls = Physics.OverlapSphere(other.gameObject.transform.position, 30f);
            foreach(var coll in colls)
            {
                try
                {
                    Rigidbody collRigid = coll.gameObject.GetComponent<Rigidbody>();
                    collRigid.transform.position = Vector3.Lerp(collRigid.transform.position, other.transform.position, 5f);
                }
                catch
                {
                    Debug.Log(coll.name);
                }
                }
            Destroy(gameObject);
        }
    }
}
