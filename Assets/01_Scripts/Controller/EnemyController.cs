using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private enum State
    {
        Idle,
        Walk,
        Attack,
        Die,
        PlayerDie
    }
    private Transform playerTransform;
    private EnemyManager enemyManager;
    private NavMeshAgent agent;
    private float walkDist = 15f;
    private float attackDist = 7f;

    private State state = State.Idle;
    private bool isDie = false;

    private Animator enemyAnim;

    private void Start()
    {
        enemyAnim = GetComponent<Animator>();
        enemyManager = GetComponent<EnemyManager>();
        agent = GetComponent<NavMeshAgent>();

        agent.updateRotation = false;
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
        if (state != State.Die && state != State.Idle)
        {
            Vector3 direction = agent.desiredVelocity;
            Quaternion rot = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 10f);
        }
    }

    private IEnumerator CheckMonsterState()
    {
        while(!isDie)
        {
            yield return new WaitForSeconds(0.3f);

            if (state == State.Die)
                yield break;
            if (state == State.PlayerDie)
                yield break;

            float distance = Vector3.Distance(transform.position, playerTransform.position);

            if (!gameObject.GetComponent<EnemyManager>().IsStopped)
            {
                if (distance <= attackDist)
                {
                    state = State.Attack;
                }
                else if (distance <= walkDist)
                {
                    state = State.Walk;
                }
                else
                {
                    state = State.Idle;
                }
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
                    agent.isStopped = true;
                    enemyAnim.SetBool("Roll", false);
                    enemyAnim.SetBool("Walk", false);
                    enemyAnim.SetBool("Open", true);
                    break;
                case State.Walk:
                    while (enemyAnim.GetCurrentAnimatorStateInfo(0).IsName("anim_open_Idle_F1") || enemyAnim.GetCurrentAnimatorStateInfo(0).IsName("anim_open"))
                    {
                        yield return new WaitForEndOfFrame();
                    }
                    agent.SetDestination(playerTransform.position);
                    enemyAnim.SetBool("Walk", true);
                    enemyAnim.SetBool("Roll", false);
                    agent.isStopped = false;
                    agent.speed = 5f;
                    break;
                case State.Attack:
                    while (enemyAnim.GetCurrentAnimatorStateInfo(0).IsName("anim_open_Idle_F1") || enemyAnim.GetCurrentAnimatorStateInfo(0).IsName("anim_open"))
                    {
                        yield return new WaitForEndOfFrame();
                    }
                    agent.SetDestination(playerTransform.position);
                    enemyAnim.SetBool("Walk", false);
                    enemyAnim.SetBool("Roll", true);
                    agent.isStopped = false;
                    agent.speed = 20f;
                    break;

                case State.Die:
                    Debug.Log("Im Die");
                    agent.isStopped = true;
                    isDie = true;
                    enemyAnim.SetBool("Open", false);
                    enemyAnim.SetBool("Roll", false);
                    enemyAnim.SetBool("Walk", false);
                    yield return new WaitForSeconds(2f);
                    this.gameObject.SetActive(false);
                    break;

                case State.PlayerDie:
                    StopAllCoroutines();
                    enemyAnim.SetBool("Roll", false);
                    enemyAnim.SetBool("Walk", false);
                    agent.isStopped = true;
                    break;
            }
            yield return new WaitForSeconds(0.3f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" && state == State.Attack)
        {
            collision.gameObject.GetComponent<PlayerController>().CurrHp -= 10f;
            collision.rigidbody.AddForce(collision.transform.forward * -10f,ForceMode.Impulse);
        }
    }
}
