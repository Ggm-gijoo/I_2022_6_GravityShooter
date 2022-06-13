using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleController : MonoBehaviour
{
    public void StartInhale(Transform origin, float radius, float force)
    {
        StartCoroutine(Inhale(origin, radius, force));
    }

    private IEnumerator Inhale(Transform origin, float radius, float force)
    {
        float timer = 0f;
        while(timer < 3f)
        {
            timer += Time.deltaTime;
            yield return null;
            Collider[] colls = Physics.OverlapSphere(origin.position, radius);
            foreach (var coll in colls)
            {
                try
                {
                    Rigidbody collRigid = coll.gameObject.GetComponent<Rigidbody>();
                    Vector3 draggedVec = origin.position - collRigid.position;
                    draggedVec.Normalize();
                    collRigid.velocity = draggedVec * force * Time.deltaTime;
                }
                catch
                {
                    Debug.Log(coll.name);
                }
            }
        }
        Collider[] explosiveColl = Physics.OverlapSphere(origin.position, radius);
        foreach (var coll in explosiveColl)
        {
            try
            {
                Rigidbody collRigid = coll.gameObject.GetComponent<Rigidbody>();
                Vector3 draggedVec = origin.position - collRigid.position;
                draggedVec.Normalize();
                collRigid.velocity -= draggedVec * force * 0.02f;
            }
            catch
            {
                Debug.Log(coll.name);
            }
        }
        timer = 0f;
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
