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
    }
}
