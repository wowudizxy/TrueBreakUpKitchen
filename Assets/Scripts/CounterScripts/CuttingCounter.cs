using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private CuttingRecipeListSO cuttingRecipeList;
    public override void Interact (Player player)
    {
        if (player.IsHaveKitchenObject())//�����ʳ��
        {
            if (!IsHaveKitchenObject())//��ǰ��̨��Ϊ��
            {
                TransferKitchenObject(player, this);
            }
            else
            {
                Debug.LogWarning("Player������ʳ�Ĳ��ҹ�̨Ҳ��ʳ��");
            }
        }
        else//���û��ʳ��
        {
            if (!IsHaveKitchenObject())//��̨Ϊ����
            {
                Debug.LogWarning("Player����û��ʳ�Ĳ��ҹ�̨Ҳû��ʳ��");
            }
            else
            {
                TransferKitchenObject(this, player);
            }
        }
    }
    public override void Operate (Player player)
    {
        if (IsHaveKitchenObject())//��̨��ʳ��
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
            print("û��CuttingKitchenObject");
        }
        
    }
}
