using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCounter : BaseCounter
{
    public static event EventHandler Trash;
    public override void Interact(Player player)
    {
        if(player.IsHaveKitchenObject())
        {
            Trash?.Invoke(this,EventArgs.Empty);
            player.DestroyKitchenObject();
        }
    }
}
