using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int talkIndex;
    public TalkManager talkManager;
    public Transform playerTransform;
    public GameObject talkPanel;
    public Text textTalk;

    public bool IsTalk { private set; get; } = false;
    private GameObject scanObject;

    private void Update()
    {
        Check();
    }

    public void Check()
    {
        RaycastHit hitInfo;
        Debug.DrawRay(playerTransform.position, playerTransform.forward, Color.red, 10f);
        if (Physics.Raycast(playerTransform.position, playerTransform.forward, out hitInfo, 10f))
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                Action(hitInfo.transform.gameObject);
            }
        }
    }

    public void Action(GameObject scanObj)
    {
        try
        {
            Time.timeScale = 0f;
            scanObject = scanObj;

            TalkData talkData = scanObject.GetComponent<TalkData>();
            Talk(talkData.id);
        }
        catch
        {

        }
        
        talkPanel.SetActive(IsTalk);
    }
    public void Talk(int id)
    {
        string talkData = talkManager.GetTalk(id, talkIndex);

        if(talkData == null)
        {
            IsTalk = false;
            talkIndex = 0;
            Time.timeScale = 1f;
            return;
        }
        textTalk.text = talkData;

        IsTalk = true;
        talkIndex++;

    }
}
