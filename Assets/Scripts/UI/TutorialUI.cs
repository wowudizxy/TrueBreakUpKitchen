using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] private GameObject uiParent;
    [SerializeField] private TextMeshProUGUI upText;
    [SerializeField] private TextMeshProUGUI downText;
    [SerializeField] private TextMeshProUGUI leftText;
    [SerializeField] private TextMeshProUGUI rightText;
    [SerializeField] private TextMeshProUGUI interactText;
    [SerializeField] private TextMeshProUGUI operateText;
    [SerializeField] private TextMeshProUGUI pauseText;


    private void Start()
    {
        GameManager.Instance.OnWaitingToStarted += GameManager_OnWaitingToStarted;
        GameManager.Instance.OnCountDownStarted += GameManager_OnCountDownStarted;
    }

    private void GameManager_OnCountDownStarted(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void GameManager_OnWaitingToStarted(object sender, System.EventArgs e)
    {
            Show();
    }
    public void UpdateVisual()
    {
        upText.text = GameInput.Instance.GetBindingType(GameInput.BindingType.Up);
        downText.text = GameInput.Instance.GetBindingType(GameInput.BindingType.Down);
        leftText.text = GameInput.Instance.GetBindingType(GameInput.BindingType.Left);
        rightText.text = GameInput.Instance.GetBindingType(GameInput.BindingType.Right);
        interactText.text = GameInput.Instance.GetBindingType(GameInput.BindingType.Interact);
        operateText.text = GameInput.Instance.GetBindingType(GameInput.BindingType.Operate);
        pauseText.text = GameInput.Instance.GetBindingType(GameInput.BindingType.Pause);
    }

    public void Show()
    {
        uiParent.SetActive(true);
        UpdateVisual();
    }
    public void Hide()
    {
        uiParent.SetActive(false);
    }
}
