using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    private TalkData talkData;
    private int randomId;

    private void Awake()
    {
        talkData = GetComponent<TalkData>();
        randomId = Random.Range(100, 106);
    }

    private void Start()
    {
        talkData.id = randomId;
    }
}
