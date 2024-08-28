using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;

public class CountDownUI : MonoBehaviour
{
    
    [SerializeField] private GameObject PrePareIcon;
    [SerializeField] private GameObject StartIcon;
    private void Start()
    {
        GameManager.Instance.OnCountDownStarted += GameManager_IntoCountDown;
    }

    private void GameManager_IntoCountDown(object sender, EventArgs e)
    {
        ShowCountDown();
    }

    public void ShowCountDown()
    {
        PrePareIcon.SetActive(true);
        Sequence sequence = DOTween.Sequence();
        sequence.Append(PrePareIcon.transform.DOScale(0, 0.4f).From())
            .AppendInterval(1)
            .Append(PrePareIcon.transform.DOScale(0, 0.2f))
            .AppendCallback(() =>
            {
                PrePareIcon.SetActive(false);
                StartIcon.SetActive(true);
            })
            .Append(StartIcon.transform.DOScale(0, 0.2f).From())
            .AppendInterval(1)
            .Append(StartIcon.transform.DOScale(0, 0.2f))
            .AppendCallback(() =>
            {
                StartIcon.SetActive(false);
            });
    }
    
}
