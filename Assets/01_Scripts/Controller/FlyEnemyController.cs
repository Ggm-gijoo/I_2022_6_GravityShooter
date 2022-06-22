using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemyController : MonoBehaviour
{
    [SerializeField]
    private float turn;
    [SerializeField]
    private GameObject beamPrefab;

    private float moveSpeed = 2f;
    private float distance = 10f;
    private Transform playerTransform;
    private Rigidbody enemyRigid;
    private EnemyManager enemyManager;

    private void Start()
    {
        playerTransform = GameObject.FindWithTag("PTF").GetComponent<Transform>();
        enemyRigid = GetComponent<Rigidbody>();
        enemyManager = GetComponent<EnemyManager>();
        StartCoroutine(MoveToPlayer());
        StartCoroutine(Fire());
    }

    private IEnumerator MoveToPlayer()
    {
        while (gameObject.GetComponent<EnemyManager>().Hp > 0 && !gameObject.GetComponent<EnemyManager>().IsStopped)
        {
            distance = Vector3.Distance(transform.position, playerTransform.position);
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

    public IEnumerator Fire()
    {
        while(distance <= 8 && enemyManager.Hp > 0)
        {
            yield return new WaitForSeconds(5f);
            Instantiate(beamPrefab, transform.position, transform.rotation);
        }
    }
}
