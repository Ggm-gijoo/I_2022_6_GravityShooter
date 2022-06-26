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

    private bool isFire = false;

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

    private void Update()
    {
        CheckHp();
    }

    public void CheckHp()
    {
        if(enemyManager.Hp <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    private IEnumerator MoveToPlayer()
    {
        while (enemyManager.Hp > 0 && !enemyManager.IsStopped)
        {
            distance = Vector3.Distance(transform.position, playerTransform.position);
            yield return null;
            if (distance <= 8)
            {
                enemyRigid.velocity = (transform.right * moveSpeed);
                if (!isFire)
                    StartCoroutine(Fire());
            }
            else
                enemyRigid.velocity = (transform.forward * moveSpeed);
            var targetRotation = Quaternion.LookRotation(playerTransform.position - transform.position);
            targetRotation = targetRotation.normalized;
            enemyRigid.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, turn));
        }
    }

    public IEnumerator Fire()
    {
        isFire = true;
        while (distance <= 8 && enemyManager.Hp > 0 && !enemyManager.IsStopped &&playerTransform.GetComponentInParent<PlayerController>().CurrHp > 0)
        {
            yield return new WaitForSeconds(1f);
            Instantiate(beamPrefab, transform.position, transform.rotation);
        }
        isFire = false;
    }
}
