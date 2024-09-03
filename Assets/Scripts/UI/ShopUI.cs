using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    
    public static event EventHandler ExchangeTime;
    public static event EventHandler ExchangeCreation;
    [SerializeField] private Button timeCardBt;
    [SerializeField] private Button CreateCardBt;
    [SerializeField] private int timeCardValue = 1;
    [SerializeField] private int CreateCardValue = 1;
    [SerializeField] private TextMeshProUGUI timeValueText;
    [SerializeField] private TextMeshProUGUI CreateValueText;
    private int playerOwnCoin = 0;
    
    private void Start()
    {
        timeValueText.text = timeCardValue.ToString();
        CreateValueText.text = CreateCardValue.ToString();
        timeCardBt.onClick.AddListener(ExchangeTimeCard);
        CreateCardBt.onClick.AddListener(ExchangeCreateCard);
    }

    private void ExchangeTimeCard()
    {
        playerOwnCoin = PlayerPrefs.GetInt(LoadingUI.COIN_COUNT, 0);
        if (playerOwnCoin >= timeCardValue)
        {
            playerOwnCoin -= timeCardValue;
            PlayerPrefs.SetInt(LoadingUI.COIN_COUNT, playerOwnCoin);
            ExchangeTime?.Invoke(this, EventArgs.Empty);
        }
        else
        {

        }
        
        
    }
    private void ExchangeCreateCard()
    {
        playerOwnCoin = PlayerPrefs.GetInt(LoadingUI.COIN_COUNT, 0);
        if (playerOwnCoin >= CreateCardValue)
        {
            playerOwnCoin -= CreateCardValue;
            PlayerPrefs.SetInt(LoadingUI.COIN_COUNT, playerOwnCoin);
            ExchangeCreation?.Invoke(this, EventArgs.Empty);
        }
        else
        {

        }
    }


}
