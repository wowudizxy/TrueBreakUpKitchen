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
    private bool isinPausePlay;
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
    private void Start()
    {
        GameManager.Instance.OnGamePaused += GameManager_OnGamePaused;
        GameManager.Instance.OnGameUnPaused += GameManager_OnGameUnPaused;
    }

    private void GameManager_OnGameUnPaused(object sender, System.EventArgs e)
    {
        if (isinPausePlay)
        {
            stoveSound.Play();
        }
    }

    private void GameManager_OnGamePaused(object sender, System.EventArgs e)
    {
        isinPausePlay = stoveSound.isPlaying;
        if (stoveSound.isPlaying)
        {
            stoveSound.Pause();
        }
    }

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
        if (player.IsHaveKitchenObject())//�����ʳ��
        {
            if (player.GetKitchenObject().TryGetComponent<PlateKitchenObject>(out PlateKitchenObject plate))//��������������
            {
                if (IsHaveKitchenObject() && plate.TryAddPlateKitchenObject(GetKitchenObject().GetKitchenObjectSO()))//��ǰ��̨����ʳ��
                {
                    SetStoveState(StoveState.Idle);
                    StopSoundStove();
                    DestroyKitchenObject();
                }
                else
                {
                    //TransferKitchenObject(player, this);
                }
            }
            else
            {
                if (!IsHaveKitchenObject())//��ǰ��̨Ϊ��
                {

                    if (fryingRecipeList.TryGetFryingRecipe(player.GetKitchenObject().GetKitchenObjectSO(),
                    out FryingRecipe inputFryingRecipe))
                    {
                        TransferKitchenObject(player, this);
                        SetStoveState(StoveState.Frying, inputFryingRecipe);
                        PlaySoundStove();
                    }
                    else if (burningRecipeList.TryGetFryingRecipe(player.GetKitchenObject().GetKitchenObjectSO(),
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
                    Debug.LogWarning("Player������ʳ�Ĳ��ҹ�̨Ҳ��ʳ��");
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
    public  void PlaySoundStove()
    {
        stoveSound.Play();
    }
    public  void StopSoundStove() 
    {  stoveSound.Pause(); }
}
