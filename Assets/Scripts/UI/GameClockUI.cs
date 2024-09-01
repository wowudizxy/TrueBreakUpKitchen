using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameClockUI : MonoBehaviour
{
    [SerializeField] private GameObject uiParent;
    [SerializeField] private Image progressBar;
    [SerializeField] private TextMeshProUGUI clockText;

    void Start()
    {
        Hide();
        GameManager.Instance.OnGamePlayingStarted += GameManager_OnGamePlayingStarted;
    }

    private void Update()
    {
        if (GameManager.Instance.IsGamePlaying())
        {
            UpdateVisual();
        }
    }

    private void UpdateVisual()
    {
        progressBar.fillAmount = GameManager.Instance.GetGamePlayingTimerNormalzed();
        clockText.text =Mathf.RoundToInt( GameManager.Instance.GetGamePlayingtimer()).ToString();
    }

    private void GameManager_OnGamePlayingStarted(object sender, System.EventArgs e)
    {
        Show();

    }

    public void Show()
    {
        uiParent.SetActive(true);
    }
    public void Hide()
    {
        uiParent.SetActive(false);
    }
}
