using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;
    private int coinCount;
    private void Start()
    {
        UpdateCoinNumber();
        ShopUI.ExchangeTime += ShopUI_ExchangeTime;
        ShopUI.ExchangeCreation += ShopUI_ExchangeCreation;
    }

    private void ShopUI_ExchangeCreation(object sender, System.EventArgs e)
    {
        UpdateCoinNumber();
    }

    private void ShopUI_ExchangeTime(object sender, System.EventArgs e)
    {
        UpdateCoinNumber();
    }
    private void UpdateCoinNumber()
    {
        coinCount = PlayerPrefs.GetInt(LoadingUI.COIN_COUNT, 0);
        coinText.text = coinCount.ToString();
    }

}
