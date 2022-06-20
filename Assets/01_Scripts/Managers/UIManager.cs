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
}
