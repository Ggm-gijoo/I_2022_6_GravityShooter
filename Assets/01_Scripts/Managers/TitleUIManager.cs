using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUIManager : MonoBehaviour
{
    [SerializeField]
    private Animator panelAnimator;

    private void Update()
    { 
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Escape) && gameObject.activeSelf)
        {
            panelAnimator.Play("PanelDisable");
        }
    }

    public void OnClickStartBtn()
    {
        LoadingSceneManager.LoadScene("Main");
    }
    public void OnClickTutorialButton()
    {
        gameObject.SetActive(true);
        panelAnimator.Play("PanelEnable");
    }

    public void EndOfDisappear()
    {
        gameObject.SetActive(false);
    }
    public void OnClickQuitBtn()
    {
        Application.Quit();
    }
}
