using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private ProgressBarUI progressBarUI;
    [SerializeField] private CuttingRecipeListSO cuttingRecipeList;
    private int cuttingCount =0;
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
            if(cuttingRecipeList.TryGetCuttingRecipe(GetKitchenObject().GetKitchenObjectSO(), out CuttingRecipe cuttingRecipe))
            {
                cuttingCount++;
                progressBarUI.UpdateProgress(cuttingCount / (float)cuttingRecipe.cuttingCountMax);
                if (cuttingCount == cuttingRecipe.cuttingCountMax)
                {
                    DestroyKitchenObject();
                    CreateKitchenObject(cuttingRecipe.output.prefab);
                    cuttingCount = 0;
                }
                
                
            }
        }
        else
        {
            print("没有CuttingKitchenObject");
        }
        
    }
}
