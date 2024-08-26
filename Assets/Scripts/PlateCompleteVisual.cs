using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCompleteVisual : MonoBehaviour
{
    [Serializable]
    public class KitchenObject_Model {
        public KitchenObjectSO KitchenObjectSO;
        public GameObject model;
    }
    [SerializeField]
    public List<KitchenObject_Model> kitchenObject_Models = new List<KitchenObject_Model>();
    public void ShowKitchenObject(KitchenObjectSO kitchenObjectSO)
    {
        foreach (var item in kitchenObject_Models)
        {
            if(kitchenObjectSO == item.KitchenObjectSO)
            {
                item.model.SetActive(true);
                return;
            }
        }
    }
}
