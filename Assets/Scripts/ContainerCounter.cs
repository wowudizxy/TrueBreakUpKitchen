using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public override void Interact (Player player)
    {
        if (player.IsHaveKitchenObject()) return;
        CreateKitchenObject(kitchenObjectSO.prefab);
        TransferKitchenObject(this,player);
    }
    public void CreateKitchenObject (GameObject kitchenObjectPrefab)
    {
        KitchenObject kitchenObject = Instantiate(kitchenObjectPrefab, GetHoldPoint(), false).GetComponent<KitchenObject>();
        SetKitchenObject(kitchenObject);
    }
}
