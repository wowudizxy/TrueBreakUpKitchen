using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public override void Interact (Player player)
    {
        if (GetKitchenObject() == null)
        {
            KitchenObject kitchenObject = Instantiate(kitchenObjectSO.prefab, GetHoldPoint(), false).GetComponent<KitchenObject>();
            SetKitchenObject(kitchenObject);
        }
        else
        {
            TransferKitchenObject(this, player);
        }
    }
}
