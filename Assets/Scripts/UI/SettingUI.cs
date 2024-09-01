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
    [SerializeField] private TextMeshProUGUI musicText;
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
            MusicManager.Instance.ChangeVolume();
            UpdateSoundText();
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
        effectSoundText.text = "��Ч��С��"+SoundManager.Instance.GetVolume();
        musicText.text = "���ִ�С��"+MusicManager.Instance.GetVolume();
    }
}
