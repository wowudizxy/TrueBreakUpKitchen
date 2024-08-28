using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class StoveCounter : BaseCounter
{
    [SerializeField] private AudioSource stoveSound;
    [SerializeField] private ProgressBarUI progressBarUI;
    [SerializeField] private StoveCounterVisual counterVisual;
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
                progressBarUI.Hide();
                counterVisual.HideStoveEffect();
                break;
            case StoveState.Frying:
                print("Fry");
                counterVisual.ShowStoveEffect();
                FryingTimer += Time.deltaTime;
                progressBarUI.UpdateProgress(FryingTimer / fryingRecipe.fryingTime);
                progressBarUI.SetColor(new Color(0, 194, 229));
                if (FryingTimer > fryingRecipe.fryingTime)
                {
                    DestroyKitchenObject();
                    CreateKitchenObject(fryingRecipe.output.prefab);
                    burningRecipeList.TryGetFryingRecipe(GetKitchenObject().GetKitchenObjectSO(),
                        out FryingRecipe newFryingRecipe);
                    SetStoveState(StoveState.Burning, newFryingRecipe);
                    PlaySoundStove();
                }
                break;
            case StoveState.Burning:
                counterVisual.ShowStoveEffect();
                FryingTimer += Time.deltaTime;
                progressBarUI.UpdateProgress(FryingTimer/ fryingRecipe.fryingTime);
                progressBarUI.SetColor(Color.Lerp(new Color(1.0f, 0.0f, 0.0f), new Color(1f, 1f, 0f), Mathf.PingPong(Time.time / 0.2f, 1.0f)));
                if (FryingTimer > fryingRecipe.fryingTime)
                {
                    DestroyKitchenObject();
                    CreateKitchenObject(fryingRecipe.output.prefab);
                    SetStoveState(StoveState.Burned);
                    StopSoundStove();
                }
                break;
            case StoveState.Burned:
                progressBarUI.Hide();
                counterVisual.HideStoveEffect();
                break;
            default:
                break;
        }
    }
    public override void Interact(Player player)
    {
        if (player.IsHaveKitchenObject())//玩家有食材
        {
            if (!IsHaveKitchenObject())//当前柜台为空
            {
                if (fryingRecipeList.TryGetFryingRecipe(player.GetKitchenObject().GetKitchenObjectSO(),
                out FryingRecipe inputFryingRecipe))
                {
                    TransferKitchenObject(player, this);
                    SetStoveState(StoveState.Frying, inputFryingRecipe);
                    PlaySoundStove();
                }
                else if(burningRecipeList.TryGetFryingRecipe(player.GetKitchenObject().GetKitchenObjectSO(),
                out FryingRecipe inputBurningRecipe))
                {
                    TransferKitchenObject(player, this);
                    SetStoveState(StoveState.Burning, inputBurningRecipe);
                    PlaySoundStove();
                }
                else
                {

                }

            }
            else
            {
                Debug.LogWarning("Player手上有食材并且柜台也有食材");
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
                SetStoveState(StoveState.Idle);
                StopSoundStove();
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
    public void PlaySoundStove()
    {
        stoveSound.Play();
    }
    public void StopSoundStove() 
    {  stoveSound.Pause(); }
}
