using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemyController : MonoBehaviour
{
    [SerializeField]
    private float turn;

    private float moveSpeed = 2f;

    private Transform playerTransform;
    private Rigidbody enemyRigid;

    private void Start()
    {
        playerTransform = GameObject.FindWithTag("PTF").GetComponent<Transform>();
        enemyRigid = GetComponent<Rigidbody>();
        StartCoroutine(MoveToPlayer());
    }

    private IEnumerator MoveToPlayer()
    {
        while (gameObject.GetComponent<EnemyManager>().Hp > 0 && !gameObject.GetComponent<EnemyManager>().IsInhaled)
        {
            float distance = Vector3.Distance(transform.position, playerTransform.position);
            yield return null;
            if(distance <= 8)
                enemyRigid.velocity = (transform.right * moveSpeed);
            else
                enemyRigid.velocity = (transform.forward * moveSpeed);
            var targetRotation = Quaternion.LookRotation(playerTransform.position - transform.position);
            targetRotation = targetRotation.normalized;
            enemyRigid.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, turn));
        }
    }
}
