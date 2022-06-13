using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private float hp = 50f;
    private bool isInhaled = false;
    private enum State
    {
        Idle,
        Walk,
        Attack,
        Die
    }

    private State state = State.Idle;
    private bool isDie = false;

    private Animator enemyAnim;

    private void Start()
    {
        enemyAnim = GetComponent<Animator>();
        enemyAnim.SetBool("Open_Anim", true);
        StartCoroutine(CheckMonsterState());
        StartCoroutine(EnemyAction());
    }

    private IEnumerator CheckMonsterState()
    {
        while(!isDie)
        {
            yield return new WaitForSeconds(0.3f);

            if (state == State.Die)
                yield break;

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
                case State.Die:
                    isDie = true;
                    enemyAnim.SetBool("Open", false);
                    break;
            }
            yield return new WaitForSeconds(0.3f);
        }
    }

    private IEnumerator enemyInhaled()
    {
        while(hp > 0 && isInhaled)
        {
            yield return new WaitForSeconds(0.5f);
            hp -= 10f;
            Debug.Log(hp);
        }
        if(hp <= 0)
        {
            state = State.Die;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BlackHole" && !isInhaled)
        {
            isInhaled = true;
            StartCoroutine(enemyInhaled());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "BlackHole" && isInhaled)
        {
            isInhaled = false;
            StopCoroutine(enemyInhaled());
        }
    }
}
