using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    public override void Interact (Player player)
    {
        if (IsHaveKitchenObject())
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
        }
    }
}
