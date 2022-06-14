using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemyMove : MonoBehaviour
{
    [SerializeField]
    private float turn;

    private float moveSpeed = 5f;

    private Transform playerTransform;
    private Rigidbody enemyRigid;

    private void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        enemyRigid = GetComponent<Rigidbody>();
    }
    public void FixedUpdate()
    {
        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
        transform.Translate(transform.forward * moveSpeed *Time.deltaTime);
        var targetRotation = Quaternion.LookRotation(playerTransform.position - transform.position);
        targetRotation = targetRotation.normalized;
        enemyRigid.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, turn));
    }
}
