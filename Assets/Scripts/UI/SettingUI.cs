using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    [SerializeField] private GameObject uiParent;
    [SerializeField] private Button effectSoundBt;
    [SerializeField] private Button musicBt;
    [SerializeField] private Button backBt;
    [SerializeField] private TextMeshProUGUI effectSoundText;
    [SerializeField] private TextMeshProUGUI musicText;

    [SerializeField] private Button upBt;
    [SerializeField] private Button downBt;
    [SerializeField] private Button leftBt;
    [SerializeField] private Button rightBt;
    [SerializeField] private Button interactBt;
    [SerializeField] private Button operateBt;
    [SerializeField] private Button pauseBt;

    [SerializeField] private TextMeshProUGUI upText;
    [SerializeField] private TextMeshProUGUI downText;
    [SerializeField] private TextMeshProUGUI leftText;
    [SerializeField] private TextMeshProUGUI rightText;
    [SerializeField] private TextMeshProUGUI interactText;
    [SerializeField] private TextMeshProUGUI operateText;
    [SerializeField] private TextMeshProUGUI pauseText;
    
    private void Start()
    {
        Hide();
        UpdateVisual();
        GamePauseUI.OnSettingUI += GamePauseUI_OnSettingUI;
        effectSoundBt.onClick.AddListener(() =>
        {
            
            SoundManager.Instance.ChangeVolume();
            UpdateVisual();
        });
        musicBt.onClick.AddListener(() =>
        {
            MusicManager.Instance.ChangeVolume();
            UpdateVisual();
        });
        backBt.onClick.AddListener(() =>
        {
            Hide();
        });
        upBt.onClick.AddListener(() =>
        {
            GameInput.Instance.ReBinding(GameInput.BindingType.Up);
        });
        downBt.onClick.AddListener(() =>
        {
            GameInput.Instance.ReBinding(GameInput.BindingType.Down);
        });
        leftBt.onClick.AddListener(() =>
        {
            GameInput.Instance.ReBinding(GameInput.BindingType.Left);
        });
        rightBt.onClick.AddListener(() =>
        {
            GameInput.Instance.ReBinding(GameInput.BindingType.Right);
        });
        interactBt.onClick.AddListener(() =>
        {
            GameInput.Instance.ReBinding(GameInput.BindingType.Interact);
        });
        operateBt.onClick.AddListener(() =>
        {
            GameInput.Instance.ReBinding(GameInput.BindingType.Operate);
        });
        pauseBt.onClick.AddListener(() =>
        {
            GameInput.Instance.ReBinding(GameInput.BindingType.Pause);
        });
    }
    public void Show()
    {
        print("setShow");
        uiParent.SetActive(true);
        GameManager.Instance.SetIsPauseActive(false);
    }

    private void GamePauseUI_OnSettingUI(object sender, EventArgs e)
    {
        print("GamePauseUI_OnSettingUI");
        Show();
    }

    public void Hide()
    {
        uiParent?.SetActive(false);
        GameManager.Instance.SetIsPauseActive(true);
    }
    private void UpdateVisual()
    {
        effectSoundText.text = "音效大小："+SoundManager.Instance.GetVolume();
        musicText.text = "音乐大小："+MusicManager.Instance.GetVolume();
        upText.text = GameInput.Instance.GetBindingType(GameInput.BindingType.Up);
        downText.text = GameInput.Instance.GetBindingType(GameInput.BindingType.Down);
        leftText.text = GameInput.Instance.GetBindingType(GameInput.BindingType.Left);
        rightText.text = GameInput.Instance.GetBindingType(GameInput.BindingType.Right);
        interactText.text = GameInput.Instance.GetBindingType(GameInput.BindingType.Interact);
        operateText.text = GameInput.Instance.GetBindingType(GameInput.BindingType.Operate);
        pauseText.text = GameInput.Instance.GetBindingType(GameInput.BindingType.Pause);
    }
    
}
