using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject uiParent;
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    [SerializeField] private RectTransform GameOverText;
    [SerializeField] private RectTransform FinishText;
    [SerializeField] private RectTransform number;
    private void Start()
    {
        GameManager.Instance.OnGameOverStarted += GameManager_OnGameOverStarted;
    }
    private void OnDestroy()
    {
        GameManager.Instance.OnGameOverStarted -= GameManager_OnGameOverStarted;
    }

    private void GameManager_OnGameOverStarted(object sender, System.EventArgs e)
    {
        Show();
        textMeshProUGUI.text = OrderManager.Instance.GetSuccessOrder().ToString();
        Sequence sequence = DOTween.Sequence();
        sequence.Append(GameOverText.DOAnchorPos(Vector2.zero, 1f).From())
            .Join(GameOverText.transform.DOScale(10f, 1f).From())
            .AppendCallback(() =>
            {
                FinishText.gameObject.SetActive(true);
            })
            .Append(FinishText.DOAnchorPos(Vector2.zero, 0.75f).From())
            .Join(FinishText.transform.DOScale(7, 0.75f).From())
            .AppendCallback(() =>
            {
                number.gameObject.SetActive(true);
            })
            .Append(number.transform.DOScale(0, 0.2f).From());
    }

    private void Show()
    {
        uiParent.SetActive(true);
    }
    private void Hide()
    {
        uiParent.SetActive(false);
    }
}
