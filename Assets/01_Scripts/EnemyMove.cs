using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private enum State
    {
        Idle,
        Walk,
        Attack,
        Die
    }
    private Transform playerTransform;
    private EnemyManager enemyManager;
    private float walkDist = 15f;
    private float attackDist = 7f;

    private State state = State.Idle;
    private bool isDie = false;

    private Animator enemyAnim;

    private void Start()
    {
        enemyAnim = GetComponent<Animator>();
        enemyManager = GetComponent<EnemyManager>();
        enemyAnim.SetBool("Open_Anim", true);
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        StartCoroutine(CheckMonsterState());
        StartCoroutine(EnemyAction());
    }

    private void Update()
    {
        if (enemyManager.Hp <= 0 && state != State.Die)
        {
            state = State.Die;
        }
    }

    private IEnumerator CheckMonsterState()
    {
        while(!isDie)
        {
            yield return new WaitForSeconds(0.3f);

            if (state == State.Die)
                yield break;

            float distance = Vector3.Distance(transform.position, playerTransform.position);

            if (distance <= attackDist)
            {
                state = State.Attack;
            }
            else if (distance <= walkDist)
            {
                state = State.Walk;
            }
            else
            state = State.Idle;
        }
    }

    private IEnumerator EnemyAction()
    {
        while (!isDie)
        {
            switch (state)
            {
                case State.Idle:
                    enemyAnim.SetBool("Roll", false);
                    enemyAnim.SetBool("Walk", false);
                    enemyAnim.SetBool("Open", true);
                    break;
                case State.Walk:
                    enemyAnim.SetBool("Walk", true);
                    enemyAnim.SetBool("Roll", false);
                    break;
                case State.Attack:
                    enemyAnim.SetBool("Walk", false);
                    enemyAnim.SetBool("Roll", true);
                    break;

                case State.Die:
                    Debug.Log("Im Die");
                    isDie = true;
                    enemyAnim.SetBool("Open", false);
                    enemyAnim.SetBool("Roll", false);
                    enemyAnim.SetBool("Walk", false);
                    break;
            }
            yield return new WaitForSeconds(0.3f);
        }
    }
}
