using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFoodCounter : ClearCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    private void Start()
    {
        ItemCardUI.UseCreateMeatCard += ItemCardUI_UseCreatMeatCard;
    }

    private void ItemCardUI_UseCreatMeatCard(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.IsGamePlaying())
        {
            if (this.GetKitchenObject() != null)
            {
                return;
            }
            CreateKitchenObject(kitchenObjectSO.prefab);
        }
        
    }
}
