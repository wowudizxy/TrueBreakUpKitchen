using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private CuttingRecipeListSO cuttingRecipeList;
    public override void Interact (Player player)
    {
        if (player.IsHaveKitchenObject())//玩家有食材
        {
            if (!IsHaveKitchenObject())//当前柜台不为空
            {
                TransferKitchenObject(player, this);
            }
            else
            {
                Debug.LogWarning("Player手上有食材并且柜台也有食材");
            }
        }
        else//玩家没有食材
        {
            if (!IsHaveKitchenObject())//柜台为不空
            {
                Debug.LogWarning("Player手上没有食材并且柜台也没有食材");
            }
            else
            {
                TransferKitchenObject(this, player);
            }
        }
    }
    public override void Operate (Player player)
    {
        if (IsHaveKitchenObject())//柜台有食材
        {
            KitchenObjectSO output = cuttingRecipeList.GetOutput(GetKitchenObject().GetKitchenObjectSO());
            if (output!=null)
            {
                DestroyKitchenObject();
                CreateKitchenObject(output.prefab);
            }
            
        }
        else
        {
            print("没有CuttingKitchenObject");
        }
        
    }
}
