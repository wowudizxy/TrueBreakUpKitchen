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
                Debug.LogWarning("Player������ʳ�Ĳ��ҹ�̨Ҳ��ʳ��");
            }
        }
        else
        {
            if(!player.IsHaveKitchenObject())
            {
                Debug.LogWarning("Player����û��ʳ�Ĳ��ҹ�̨Ҳû��ʳ��");
            }
            else
            {
                player.TransferKitchenObject(player, this);
            }
        }
    }
}
