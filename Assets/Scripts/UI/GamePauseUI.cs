using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour
{
    [SerializeField] private GameObject uiParent;
    [SerializeField] private Button continueBt;
    [SerializeField] private Button toMenuBt;
    [SerializeField] private Button restartBt;
    private void Start()
    {
        GameManager.Instance.OnGamePaused += GameManager_OnGamePaused;
        GameManager.Instance.OnGameUnPaused += GameManager_OnGameUnPaused;
        uiParent.SetActive(false);
        continueBt.onClick.AddListener(() =>
        {
            GameManager.Instance.SwitchPause();
        });
        restartBt.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.GameScene);
            Hide();
        });
        toMenuBt.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.GameMenu);
            Hide();
        });
    }

    private void GameManager_OnGameUnPaused(object sender, System.EventArgs e)
    {
        print("GameManager_OnGameUnPaused");
        Hide();
    }

    private void GameManager_OnGamePaused(object sender, System.EventArgs e)
    {
        print("GameManager_OnGamePaused");
        Show();
    }

    public void Show()
    {
        if(uiParent != null)
        {
            uiParent.SetActive(true);
        }
            
        
    }

    public void Hide()
    {

        if (uiParent != null)
        {
            uiParent.SetActive(false);
        }

    }
    private void OnDestroy()
    {
        GameManager.Instance.OnGamePaused -= GameManager_OnGamePaused;
        GameManager.Instance.OnGameUnPaused -= GameManager_OnGameUnPaused;
    }


}
