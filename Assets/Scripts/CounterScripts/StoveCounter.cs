using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounter : BaseCounter
{
    private float FryingTimer = 0;
    private FryingRecipe fryingRecipe;
    public enum StoveState
    {
        Idle,
        Frying,
        Burning,
        Burned
    }
    private StoveState state = StoveState.Idle;
    [SerializeField] private FryingRecipeListSO fryingRecipeList;
    [SerializeField] private FryingRecipeListSO burningRecipeList;
    private void Update()
    {
        switch (state)
        {
            case StoveState.Idle:
                break;
            case StoveState.Frying:
                FryingTimer += Time.deltaTime;
                if (FryingTimer > fryingRecipe.fryingTime)
                {
                    DestroyKitchenObject();
                    CreateKitchenObject(fryingRecipe.output.prefab);
                    burningRecipeList.TryGetFryingRecipe(GetKitchenObject().GetKitchenObjectSO(),
                        out FryingRecipe newFryingRecipe);
                    SetStoveState(StoveState.Burning, newFryingRecipe);
                }
                break;
            case StoveState.Burning:
                FryingTimer += Time.deltaTime;
                if (FryingTimer > fryingRecipe.fryingTime)
                {
                    DestroyKitchenObject();
                    CreateKitchenObject(fryingRecipe.output.prefab);
                    SetStoveState(StoveState.Burned);
                }
                break;
            case StoveState.Burned:
                break;
            default:
                break;
        }
    }
    public override void Interact(Player player)
    {
        if (player.IsHaveKitchenObject())//�����ʳ��
        {
            if (!IsHaveKitchenObject())//��ǰ��̨Ϊ��
            {
                if (fryingRecipeList.TryGetFryingRecipe(player.GetKitchenObject().GetKitchenObjectSO(),
                out FryingRecipe inputFryingRecipe))
                {
                    TransferKitchenObject(player, this);
                    SetStoveState(StoveState.Frying, inputFryingRecipe);
                }else if(burningRecipeList.TryGetFryingRecipe(player.GetKitchenObject().GetKitchenObjectSO(),
                out FryingRecipe inputBurningRecipe))
                {
                    TransferKitchenObject(player, this);
                    SetStoveState(StoveState.Burning, inputBurningRecipe);
                }
                else
                {

                }

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
                SetStoveState(StoveState.Idle);
            }
        }
    }
    public void SetStoveState(StoveState targetState,FryingRecipe inputFryingRecipe)
    {
        FryingTimer = 0;
        state = targetState;
        fryingRecipe = inputFryingRecipe;
    }
    public void SetStoveState(StoveState tragetState)
    {
        FryingTimer = 0;
        state = tragetState;
    }
}
