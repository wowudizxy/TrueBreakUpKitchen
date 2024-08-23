using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class KitchenObjectHolder : MonoBehaviour
{
    private KitchenObject kitchenObject;
    [SerializeField] private Transform holdPoint;

    public void TransferKitchenObject (KitchenObjectHolder sourceHolder, KitchenObjectHolder targetHolder)
    {
        if (sourceHolder.GetKitchenObject() == null)
        {
            Debug.LogWarning("原持有者上没有食物");
            return;
        }
        if (targetHolder.GetKitchenObject() != null)
        {
            Debug.LogWarning("目标持有者上有食物");
            return;
        }
        targetHolder.AddKitchenObject(sourceHolder.GetKitchenObject());
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
