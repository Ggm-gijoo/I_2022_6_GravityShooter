using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int talkIndex;
    public int resqueCount = 0;

    public TalkManager talkManager;
    public Transform playerTransform;

    public GameObject talkPanel;
    public GameObject resquePanel;
    public GameObject fPanel;

    public GameObject Aim;
    public GameObject mainCamera;
    public GameObject gameOverCamera;

    public Text textTalk;

    private Text fText;
    private Text resqueText;
    private string textWriter;

    public bool IsTalk { private set; get; } = false;
    public bool IsFirstTalk { private set; get; } = false;
    public bool IsTyping { private set; get; } = false;

    private GameObject scanObject;
    private UIManager uiManager;
    private EnemySpawner enemySpawner;

    private void Start()
    {
        fText = fPanel.GetComponentInChildren<Text>();
        resqueText = resquePanel.GetComponentInChildren<Text>();

        uiManager = GetComponent<UIManager>();
        enemySpawner = GetComponent<EnemySpawner>();

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;

        mainCamera.SetActive(true);
        gameOverCamera.SetActive(false);

        resquePanel.SetActive(false);
        fPanel.SetActive(false);
        talkPanel.SetActive(true);
        Talk(0);
    }

    private void Update()
    {
        Check();
        ResqueCheck();

        if(enemySpawner.IsGameOver)
        {
            mainCamera.SetActive(false);
            uiManager.OnEnableGameOverPanel();
            gameOverCamera.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!uiManager.pausePanel.activeSelf)
                uiManager.OnEnablePausePanel();
            else
                uiManager.OnDisablePausePanel();
        }
    }
    public void Check()
    {
        if (!IsFirstTalk)
        {
            if (Input.GetKeyDown(KeyCode.F) && !IsTyping)
            {
                fPanel.SetActive(false);
                talkPanel.SetActive(true);
                Talk(0);
            }
            talkPanel.SetActive(IsTalk);
            resquePanel.SetActive(!IsTalk);
        }
        else
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(playerTransform.position, playerTransform.forward, out hitInfo, 5f))
            {
                if (hitInfo.transform.GetComponent<TalkData>() != null)
                {
                    fPanel.SetActive(!IsTalk);
                    resquePanel.SetActive(!IsTalk);
                    TalkData hitTalkData = hitInfo.transform.GetComponent<TalkData>();
                    if(hitTalkData.id < 100)
                    {
                        fText.text = "    무전";
                    }
                    else if(hitTalkData.id < 1000)
                    {
                        fText.text = "    구조하기";
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
                fPanel.SetActive(false);
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
            if(!IsTalk && talkData.id < 1000 && talkData.id >= 100)
            {
                resqueCount++;
                Destroy(scanObj);
            }
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
            resquePanel.SetActive(true);
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

    public void ResqueCheck()
    {
        resqueText.text = $"구조인원 {resqueCount} / 10";
        if (resqueCount >= 10)
        {
            SceneManager.LoadScene("Clear");
        }
    }
}
