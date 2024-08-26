using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObjectGridUI : MonoBehaviour
{
    [SerializeField] KitchenObjectIcon icon;
    public void ShowKitchenObjectUI(KitchenObjectSO kitchenObjectSO)
    {
        KitchenObjectIcon kitchenObjectIcon =  Instantiate(icon,transform);
        kitchenObjectIcon.UpdataIcon(kitchenObjectSO);
        kitchenObjectIcon.gameObject.SetActive(true);
    }
}
