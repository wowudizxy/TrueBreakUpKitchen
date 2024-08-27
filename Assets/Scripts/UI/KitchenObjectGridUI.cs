using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObjectGridUI : MonoBehaviour
{
    KitchenObjectIcon icon;
    private void Start()
    {
        icon = transform.Find("KitchenObjectIcon").GetComponent<KitchenObjectIcon>();
    }
    public void ShowKitchenObjectUI(KitchenObjectSO kitchenObjectSO)
    {
        KitchenObjectIcon kitchenObjectIcon =  Instantiate(icon,transform);
        kitchenObjectIcon.UpdataIcon(kitchenObjectSO);
        kitchenObjectIcon.gameObject.SetActive(true);
    }
}
