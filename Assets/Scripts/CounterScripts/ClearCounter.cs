using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    public override void Interact (Player player)
    {
        if (player.IsHaveKitchenObject())//�����ʳ��
        {
            if (player.GetKitchenObject().TryGetComponent<PlateKitchenObject>(out PlateKitchenObject plate))//��������������
            {
                if (IsHaveKitchenObject()&&plate.TryAddPlateKitchenObject(GetKitchenObject().GetKitchenObjectSO()))//��ǰ��̨����ʳ��
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
                if (!IsHaveKitchenObject())//������ʳ�ģ���û���ӣ���̨Ϊ�գ��ͽ�ʳ�ķ��ڹ�̨��
                {
                    TransferKitchenObject(player,this);
                }
                else
                {

                }
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
        /*if (IsHaveKitchenObject())
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
        }*/
    }
}
