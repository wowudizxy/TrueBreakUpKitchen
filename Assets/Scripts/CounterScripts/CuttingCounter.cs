using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CuttingCounter : BaseCounter
{
    private Animator _animator;
    [SerializeField] private ProgressBarUI progressBarUI;
    [SerializeField] private CuttingRecipeListSO cuttingRecipeList;
    private int cuttingCount =0;
    private void Start()
    {
        _animator = transform.Find("CuttingCounter_Visual").GetComponent<Animator>();
    }
    private void Cut()
    {
        cuttingCount++;
        _animator.SetTrigger("Cut");
    }
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
}
