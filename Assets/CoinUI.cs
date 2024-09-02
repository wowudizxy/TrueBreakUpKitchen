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
        coinCount = PlayerPrefs.GetInt(LoadingUI.COIN_COUNT, 0);
        coinText.text = coinCount.ToString();
    }
}
