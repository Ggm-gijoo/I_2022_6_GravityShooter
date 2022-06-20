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
    public GameObject FPanel;
    public GameObject Aim;
    public Text textTalk;
    private Text fText;
    private string textWriter;

    public bool IsTalk { private set; get; } = false;
    public bool IsFirstTalk { private set; get; } = false;
    public bool IsTyping { private set; get; } = false;

    private GameObject scanObject;

    private void Awake()
    {
        fText = FPanel.GetComponentInChildren<Text>();

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;

        FPanel.SetActive(false);
        talkPanel.SetActive(true);
        Talk(0);
    }

    private void Update()
    {
        Check();
    }
    public void Check()
    {
        if (!IsFirstTalk)
        {
            if (Input.GetKeyDown(KeyCode.F) && !IsTyping)
            {
                FPanel.SetActive(false);
                talkPanel.SetActive(true);
                Talk(0);
            }
            talkPanel.SetActive(IsTalk);
        }
        else
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(playerTransform.position, playerTransform.forward, out hitInfo, 5f))
            {
                if (hitInfo.transform.GetComponent<TalkData>() != null)
                {
                    FPanel.SetActive(!IsTalk);
                    TalkData hitTalkData = hitInfo.transform.GetComponent<TalkData>();
                    if(hitTalkData.id < 100)
                    {
                        fText.text = "    무전";
                    }
                    else if(hitTalkData.id < 1000)
                    {
                        fText.text = "    대화하기";
                    }
                    else if(hitTalkData.id < 10000)
                    {
                        fText.text = "    조사하기";
                    }
                    
                }
                if (Input.GetKeyDown(KeyCode.F) && !IsTyping)
                {
                    Action(hitInfo.transform.gameObject);
                }
            }
            else
            {
                FPanel.SetActive(false);
            }
        }
    }

    public void Action(GameObject scanObj)
    {
        try
        {
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
        Time.timeScale = 0f;
        Aim.SetActive(false);
        string talkData = talkManager.GetTalk(id, talkIndex);

        if(talkData == null)
        {
            IsTalk = false;
            IsFirstTalk = true;
            talkIndex = 0;
            Time.timeScale = 1f;
            Aim.SetActive(true);
            return;
        }
        IsTalk = true;
        StartCoroutine(TypingText(talkData));
        talkIndex++;

    }
    private IEnumerator TypingText(string talkData)
    {
        IsTyping = true;
        textWriter = "";
        int i = 0;
        yield return null;
        while (textTalk.text != talkData)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                textTalk.text = talkData;
                IsTyping = false;
                yield break;
            }
            textWriter += talkData[i];

            textTalk.text = textWriter;
            i++;
            yield return new WaitForSecondsRealtime(0.02f);
        }
        IsTyping = false;
    }
}
