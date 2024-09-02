using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryResultUI : MonoBehaviour
{
    [SerializeField] private GameObject successDelivery;
    [SerializeField] private GameObject failureDelivery;

    private void Start()
    {
        OrderManager.Instance.OnRecipeSuccessed += OrderManager_OnRecipeSuccessed;
        OrderManager.Instance.OnRecipeFailed += OrderManager_OnRecipeFaile;
    }

    private void OrderManager_OnRecipeFaile(object sender, System.EventArgs e)
    {
        failureDelivery.SetActive(true);
        Sequence sequence = DOTween.Sequence();
        sequence.Append(failureDelivery.transform.DOScale(0, 0.4f).From())
            .Append(failureDelivery.transform.DORotate(new Vector3(0, 0, 4), 0.2f))
            .Append(failureDelivery.transform.DORotate(new Vector3(0, 0, -4), 0.2f))
            .AppendInterval(0.4f)
            .AppendCallback(() =>
            {
                failureDelivery.SetActive(false);
            });
    }

    private void OrderManager_OnRecipeSuccessed(object sender, System.EventArgs e)
    {
        
        successDelivery.SetActive(true);
        Sequence sequence = DOTween.Sequence();
        sequence.Append(successDelivery.transform.DOScale(0, 0.4f).From())
            .Append(successDelivery.transform.DORotate(new Vector3(0, 0, 4), 0.2f))
            .Append(successDelivery.transform.DORotate(new Vector3(0, 0, -4), 0.2f))
            .AppendInterval(0.4f)
            .AppendCallback(() =>
            {
                successDelivery.SetActive(false);
            });
    }
}
