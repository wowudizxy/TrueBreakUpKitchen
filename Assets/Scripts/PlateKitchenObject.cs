using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    [SerializeField] private KitchenObjectGridUI kitchenGridUI;
    [SerializeField] private PlateCompleteVisual plateCompleteVisual;
    [SerializeField] private List<KitchenObjectSO> ablePutOnPlateListSO;
    private List<KitchenObjectSO> onPlateKitchenListSO = new List<KitchenObjectSO>();

    public bool TryAddPlateKitchenObject(KitchenObjectSO kitchenObjectSO)
    {
        if (!ablePutOnPlateListSO.Contains(kitchenObjectSO) ||onPlateKitchenListSO.Contains(kitchenObjectSO))
        {
            return false;
        }
        plateCompleteVisual.ShowKitchenObject(kitchenObjectSO);
        kitchenGridUI.ShowKitchenObjectUI(kitchenObjectSO);
        onPlateKitchenListSO.Add(kitchenObjectSO);
        
        return true;
       
    }
}
