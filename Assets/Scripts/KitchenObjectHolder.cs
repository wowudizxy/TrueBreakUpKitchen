using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class KitchenObjectHolder : MonoBehaviour
{
    private KitchenObject kitchenObject;
    [SerializeField] private Transform holdPoint;

    public void TransferKitchenObject (ClearCounter sourceCounter, ClearCounter targetCounter)
    {
        if (sourceCounter.GetKitchenObject() == null)
        {
            Debug.LogWarning("Ŀǰ��̨��û��ʳ��");
            return;
        }
        if (targetCounter.GetKitchenObject() != null)
        {
            Debug.LogWarning("Ŀ���̨����ʳ��");
            return;
        }
        targetCounter.AddKitchenObject(sourceCounter.GetKitchenObject());
        ClearKitchenObject();
    }
    private void AddKitchenObject (KitchenObject kitchenObject)
    {
        kitchenObject.transform.SetParent(holdPoint, false);
        this.kitchenObject = kitchenObject;
    }
    public KitchenObject GetKitchenObject ()
    {
        return kitchenObject;
    }
    public Transform GetHoldPoint ()
    {
        return holdPoint;
    }
    private void ClearKitchenObject ()
    {
        kitchenObject = null;
    }
    public void SetKitchenObject (KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }
}
