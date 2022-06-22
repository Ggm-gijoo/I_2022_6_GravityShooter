using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmManager : MonoBehaviour
{
    public enum State
    {
        Basic,
        Warning
    }
    public State state = State.Basic;
    [SerializeField]
    private GameObject[] bgms;

    private void Start()
    {
        StartCoroutine(CheckState());
    }

    private IEnumerator CheckState()
    {
        while (true)
        {
            switch (state)
            {
                case State.Basic:
                    bgms[1].SetActive(false);
                    bgms[0].SetActive(true);
                    break;
                case State.Warning:
                    bgms[0].SetActive(false);
                    bgms[1].SetActive(true);
                    break;
            }
            yield return new WaitForSeconds(0.3f);
        }
    }

}
