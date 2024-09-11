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
        ShopUI.ExchangeTime += OnExchangeTime;
        ShopUI.ExchangeCreation += OnExchangeCreation;
    }

    private void OnDestroy()
    {
        ShopUI.ExchangeTime -= OnExchangeTime;
        ShopUI.ExchangeCreation -= OnExchangeCreation;
    }

    private void OnExchangeTime(object sender, System.EventArgs e)
    {
        UpdateCoinNumber();
    }

    private void OnExchangeCreation(object sender, System.EventArgs e)
    {
        UpdateCoinNumber();
    }

    private void UpdateCoinNumber()
    {
        coinCount = PlayerPrefs.GetInt(LoadingUI.COIN_COUNT, 0);
        coinText.text = coinCount.ToString();
    }
}
