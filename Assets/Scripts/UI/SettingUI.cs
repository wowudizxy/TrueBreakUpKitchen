using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    [SerializeField] private GameObject uiParent;
    [SerializeField] private Button effectSoundBt;
    [SerializeField] private Button musicBt;
    [SerializeField] private Button backBt;
    [SerializeField] private TextMeshProUGUI effectSoundText;
    public static bool IsActive { get; private set; }
    private void Start()
    {
        Hide();
        UpdateSoundText();
        GamePauseUI.OnSettingUI += GamePauseUI_OnSettingUI;
        effectSoundBt.onClick.AddListener(() =>
        {
            
            SoundManager.Instance.ChangeVolume();
            UpdateSoundText();
        });
        musicBt.onClick.AddListener(() =>
        {

        });
        backBt.onClick.AddListener(() =>
        {
            Hide();
        });
    }
    public void Show()
    {
        uiParent.SetActive(true);
        IsActive = false;
    }

    private void GamePauseUI_OnSettingUI(object sender, EventArgs e)
    {
        Show();
    }

    public void Hide()
    {
        uiParent?.SetActive(false);
        IsActive = true;
    }
    private void UpdateSoundText()
    {
        effectSoundText.text = "“Ù–ß¥Û–°£∫"+SoundManager.Instance.GetVolume().ToString();
    }
}
