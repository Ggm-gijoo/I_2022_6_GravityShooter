using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;
    [SerializeField]
    private Image hpBarImage;
    [SerializeField]
    private Text hpText;

    public GameObject gameOverPanel;
    public GameObject pausePanel;

    private Animator gameOverPanelAnim;
    private GameManager gameManager;

    private bool isGameOverPanelOn = false;


    private void Start()
    {
        gameOverPanelAnim = gameOverPanel.GetComponent<Animator>();
        gameManager = GetComponent<GameManager>();
    }

    private void Update()
    {
        UpdateHpBar();
    }

    public void UpdateHpBar()
    {
        hpBarImage.fillAmount = playerController.CurrHp / playerController.InitHp;
        hpText.text = $"HP {playerController.CurrHp} / {playerController.InitHp}";

        if (playerController.CurrHp <= playerController.InitHp * 0.2)
        {
            hpBarImage.color = Color.red;
        }
        else if (playerController.CurrHp <= playerController.InitHp * 0.5)
        {
            hpBarImage.color = Color.yellow;
        }
        else if (playerController.CurrHp < playerController.InitHp)
        {
            hpBarImage.color = Color.green;
        }
        else
        {
            hpBarImage.color = Color.cyan;
        }
    }

    public void OnEnablePausePanel()
    {
        if (!gameManager.IsTalk)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
            Cursor.visible = true;
        }
    }

    public void OnEnableGameOverPanel()
    {
        if(!isGameOverPanelOn)
        {
            isGameOverPanelOn = true;
            Cursor.visible = true;
            gameOverPanel.SetActive(true);
            gameOverPanelAnim.Play("GameOverPanelEnable");
        }
    }

    public void OnClickReStart()
    {
        Cursor.visible = false;
        LoadingSceneManager.LoadScene("Main");
    }

    public void OnClickReturnToPlay()
    {
        if (!gameManager.IsTalk)
        {
            pausePanel.SetActive(false);
            Cursor.visible = false;
            Time.timeScale = 1;
        }
    }

    public void OnClickToTitle()
    {
        if (!gameManager.IsTalk)
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1;
            LoadingSceneManager.LoadScene("Title");
        }
    }

    public void OnClickQuit()
    {
        if (!gameManager.IsTalk)
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1;
            Application.Quit();
        }
    }
    public void OnDisablePausePanel()
    {
        if (!gameManager.IsTalk)
        {
            Cursor.visible = false;
            pausePanel.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
