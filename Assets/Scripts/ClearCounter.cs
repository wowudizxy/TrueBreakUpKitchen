using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : KitchenObjectHolder
{
    [SerializeField] private ClearCounter targetCounter;
    
    [SerializeField] private GameObject selectCounter;
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    

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
        if(GetKitchenObject() == null)
        {
            KitchenObject kitchenObject = Instantiate(kitchenObjectSO.prefab, GetHoldPoint(), false).GetComponent<KitchenObject>();
            SetKitchenObject(kitchenObject);
        }
        else
        {
            TransferKitchenObject (this, Player.Instance);
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
    
}
