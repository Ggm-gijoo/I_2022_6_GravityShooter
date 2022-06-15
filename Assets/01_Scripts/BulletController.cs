using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float moveSpeed = 20f;
    private float timer = 0f;

    [SerializeField]
    private GameObject blackHolePrefab;

    private void OnMove()
    {
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        while (timer < 5f)
        {
            timer += Time.deltaTime;
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            yield return null;
        }
        timer = 0f;
        Destroy(gameObject);
    }

    private void BlackHoleMove(Transform origin, float radius, float force)
    {
        Collider[] colls = Physics.OverlapSphere(origin.position, radius);
        foreach (var coll in colls)
        {
            try
            {
                Rigidbody collRigid = coll.gameObject.GetComponent<Rigidbody>();
                Vector3 draggedVec = origin.position - collRigid.position;
                draggedVec.Normalize();
                collRigid.velocity = draggedVec * force;
            }
            catch
            {
                Debug.Log(coll.name);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player" && other.gameObject.tag != "BlackHole")
        {
            Debug.Log($"�浹ü : {other.name}");
            GameObject blackHole = Instantiate(blackHolePrefab, gameObject.transform.position, gameObject.transform.rotation);
            blackHole.GetComponent<BlackHoleController>().StartInhale(blackHole.transform,7f,750f);
            Destroy(gameObject);
            if(other.gameObject.tag == "Enemy")
            {
                Destroy(other.gameObject);
            }
        }
    }
}
