using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CuttingCounter : BaseCounter
{
    public static event EventHandler OnCut;
    [SerializeField] private CuttingCounterVisual counterVisual;
    [SerializeField] private ProgressBarUI progressBarUI;
    [SerializeField] private CuttingRecipeListSO cuttingRecipeList;
    private int cuttingCount =0;
    
    private void Cut()
    {
        cuttingCount++;
        counterVisual.Cut();
        OnCut?.Invoke(this,EventArgs.Empty);
    }
    public override void Interact (Player player)
    {
        if (player.IsHaveKitchenObject())//玩家有食材
        {
            if (player.GetKitchenObject().TryGetComponent<PlateKitchenObject>(out PlateKitchenObject plate))//并且手上有盘子
            {
                if (IsHaveKitchenObject() && plate.TryAddPlateKitchenObject(GetKitchenObject().GetKitchenObjectSO()))//当前柜台上有食材
                {
                    DestroyKitchenObject();
                }
                else
                {
                    TransferKitchenObject(player, this);
                }
            }
            else
            {
                if (!IsHaveKitchenObject())//手上有食材，没盘子，柜台为空，就将食材放在柜台上
                {
                    TransferKitchenObject(player, this);
                }
                else
                {
                    if (GetKitchenObject().TryGetComponent<PlateKitchenObject>(out plate))
                    {
                        if (plate.TryAddPlateKitchenObject(player.GetKitchenObject().GetKitchenObjectSO()))
                        {
                            player.DestroyKitchenObject();
                        }
                    }
                }
            }

            /*if (!IsHaveKitchenObject())//当前柜台空
            {
                TransferKitchenObject(player, this);
            }
            else
            {
                Debug.LogWarning("Player手上有食材并且柜台也有食材");
            }*/
        }
        else//玩家没有食材
        {
            if (!IsHaveKitchenObject())//柜台空
            {
                Debug.LogWarning("Player手上没有食材并且柜台也没有食材");
            }
            else
            {
                TransferKitchenObject(this, player);
                progressBarUI.Hide();
            }
        }
    }
    public override void Operate (Player player)
    {
        if (IsHaveKitchenObject())//柜台有食材
        {
            if(cuttingRecipeList.TryGetCuttingRecipe(GetKitchenObject().GetKitchenObjectSO(), out CuttingRecipe cuttingRecipe))
            {
                Cut();
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
    public static void ClearStaticData()
    {
        OnCut = null;
    }
}
