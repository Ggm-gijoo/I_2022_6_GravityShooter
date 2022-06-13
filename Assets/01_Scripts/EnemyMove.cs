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

    private State state = State.Idle;
    private bool isDie = false;

    private Animator enemyAnim;

    private void Update()
    {
        if (EnemyManager.Instance().Hp <= 0 && state != State.Die)
        {
            state = State.Die;
        }
    }

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
}
