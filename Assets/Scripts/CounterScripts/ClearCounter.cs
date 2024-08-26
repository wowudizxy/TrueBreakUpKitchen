using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    public override void Interact (Player player)
    {
        if (player.IsHaveKitchenObject())//玩家有食材
        {
            if (player.GetKitchenObject().TryGetComponent<PlateKitchenObject>(out PlateKitchenObject plate))//并且手上有盘子
            {
                if (IsHaveKitchenObject()&&plate.TryAddPlateKitchenObject(GetKitchenObject().GetKitchenObjectSO()))//当前柜台上有食材
                {
                    DestroyKitchenObject();
                }
                else
                {
                    TransferKitchenObject(player,this);
                }
            }
            else
            {
                if (!IsHaveKitchenObject())//手上有食材，但没盘子，柜台为空，就将食材放在柜台上
                {
                    TransferKitchenObject(player,this);
                }
                else
                {
                    if(GetKitchenObject().TryGetComponent<PlateKitchenObject>(out plate))
                    {
                        if (plate.TryAddPlateKitchenObject(player.GetKitchenObject().GetKitchenObjectSO()))
                        {
                            player.DestroyKitchenObject();
                        }
                    }
                }
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
        /*if (IsHaveKitchenObject())
        {
            if (!player.IsHaveKitchenObject())
            {
                TransferKitchenObject(this, player);
            }
            else
            {
                Debug.LogWarning("Player手上有食材并且柜台也有食材");
            }
        }
        else
        {
            if(!player.IsHaveKitchenObject())
            {
                Debug.LogWarning("Player手上没有食材并且柜台也没有食材");
            }
            else
            {
                player.TransferKitchenObject(player, this);
            }
        }*/
    }
}
