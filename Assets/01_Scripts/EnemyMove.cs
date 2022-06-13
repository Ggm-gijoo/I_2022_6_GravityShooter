using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private float hp = 50f;
    private bool isInhaled = false;

    private Animator enemyAnim;

    private void Start()
    {
        enemyAnim = GetComponent<Animator>();
        enemyAnim.SetBool("Open_Anim", true);
    }

    private IEnumerator enemyInhaled()
    {
        while(hp > 0 && isInhaled)
        {
            yield return new WaitForSeconds(0.5f);
            hp -= 10f;
            Debug.Log(hp);
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
