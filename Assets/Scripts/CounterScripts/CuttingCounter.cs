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
        if (player.IsHaveKitchenObject())//�����ʳ��
        {
            if (player.GetKitchenObject().TryGetComponent<PlateKitchenObject>(out PlateKitchenObject plate))//��������������
            {
                if (IsHaveKitchenObject() && plate.TryAddPlateKitchenObject(GetKitchenObject().GetKitchenObjectSO()))//��ǰ��̨����ʳ��
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
                if (!IsHaveKitchenObject())//������ʳ�ģ�û���ӣ���̨Ϊ�գ��ͽ�ʳ�ķ��ڹ�̨��
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

            /*if (!IsHaveKitchenObject())//��ǰ��̨��
            {
                TransferKitchenObject(player, this);
            }
            else
            {
                Debug.LogWarning("Player������ʳ�Ĳ��ҹ�̨Ҳ��ʳ��");
            }*/
        }
        else//���û��ʳ��
        {
            if (!IsHaveKitchenObject())//��̨��
            {
                Debug.LogWarning("Player����û��ʳ�Ĳ��ҹ�̨Ҳû��ʳ��");
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
        if (IsHaveKitchenObject())//��̨��ʳ��
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
            print("û��CuttingKitchenObject");
        }
        
    }
    public static void ClearStaticData()
    {
        OnCut = null;
    }
}
