using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private ContainerCounterVisual counterVisual;
    public override void Interact (Player player)
    {
        if (player.IsHaveKitchenObject()) return;
        counterVisual.Open();
        CreateKitchenObject(kitchenObjectSO.prefab);
        TransferKitchenObject(this,player);
    }
    
}
