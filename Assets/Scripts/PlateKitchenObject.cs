using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    [SerializeField] private List<KitchenObjectSO> ablePutOnPlateListSO;
    private List<KitchenObjectSO> onPlateKitchenListSO = new List<KitchenObjectSO>();

    public bool TryAddPlateKitchenObject(KitchenObjectSO kitchenObjectSO)
    {
        if (!ablePutOnPlateListSO.Contains(kitchenObjectSO) ||onPlateKitchenListSO.Contains(kitchenObjectSO))
        {
            return false;
        }
        onPlateKitchenListSO.Add(kitchenObjectSO);
        return true;
       
    }
}
