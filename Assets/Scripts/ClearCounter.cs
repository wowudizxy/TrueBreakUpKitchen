using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private ClearCounter targetCounter;
    private KitchenObject kitchenObject;
    [SerializeField] private GameObject selectCounter;
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform point;

    [SerializeField]private bool test = false;

    private void Update ()
    {
        if (test && Input.GetMouseButtonDown(0))
        {
            TransferKitchenObject(this, targetCounter);
        }
    }
    public void Interact ()
    {
        if(kitchenObject == null)
        {
            kitchenObject = Instantiate(kitchenObjectSO.prefab, point, false).GetComponent<KitchenObject>();
        }
    }
    public void SelectCounter ()
    {
        selectCounter.SetActive(true);
    }
    public void CancelSelect ()
    {
        selectCounter.SetActive(false);
    }
    private void TransferKitchenObject (ClearCounter sourceCounter,ClearCounter targetCounter)
    {
        if (sourceCounter.GetKitchenObject() == null)
        {
            Debug.LogWarning("目前柜台上没有食物");
            return;
        }
        if (targetCounter.GetKitchenObject() != null)
        {
            Debug.LogWarning("目标柜台上有食物");
            return;
        }
        targetCounter.AddKitchenObject(sourceCounter.GetKitchenObject());
        ClearKitchenObject();
    }
    private void AddKitchenObject (KitchenObject kitchenObject)
    {
        kitchenObject.transform.SetParent(point, false);
        this.kitchenObject = kitchenObject;
    }
    private KitchenObject GetKitchenObject ()
    {
        return kitchenObject;
    }
    private void ClearKitchenObject ()
    {
        kitchenObject = null;
    }
}
