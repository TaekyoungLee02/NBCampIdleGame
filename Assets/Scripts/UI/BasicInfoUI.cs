using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BasicInfoUI : MonoBehaviour
{
    public Image hp;
    public TextMeshProUGUI coin;
    public TextMeshProUGUI currentStage;

    public Player player;
    public StageSelect stage;

    private void Update()
    {
        hp.fillAmount = (float)player.Stat.curHP / player.Stat.maxHP;

        coin.text = "Coin : " + (player.Stat as PlayerStat).Coin;

        currentStage.text = "Current Stage : " + stage.StageNum;
    }

}
