using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemCardUI : MonoBehaviour
{
    public const string TIME_CARD_COUNT = "TimeCardCount";
    public const string CREATE_CARD_COUNT = "CreateCardCount";
    public static event EventHandler<int> UseTimeCard;
    public static event EventHandler UseCreateMeatCard;
    private int extraTime = 5;
    [SerializeField] private Button extraTimeBt;
    [SerializeField] private Button createMeatBt;
    [SerializeField] private TextMeshProUGUI extraTimeText;
    [SerializeField] private TextMeshProUGUI createMeatText;
    private int timeCardCount;
    private int createCardcount;

    [SerializeField] private CreateFoodCounter createFoodCounter;
    private void Start()
    {
        timeCardCount = PlayerPrefs.GetInt(TIME_CARD_COUNT, 0);
        extraTimeText.text = " £”‡£∫" + timeCardCount;
        createCardcount = PlayerPrefs.GetInt(CREATE_CARD_COUNT, 0);
        createMeatText.text = " £”‡£∫" + createCardcount;
        extraTimeBt.onClick.AddListener(OnUseTimeCard);
        createMeatBt.onClick.AddListener(OnUseCreateMeatCard);

        GameInput.Instance.TimeCardHandler += (sender, e) => OnUseTimeCard(); // ∂©‘ƒ TimeCard µƒ ‰»Î ¬º˛
        GameInput.Instance.CreateCardHandler += (sender, e) => OnUseCreateMeatCard(); // ∂©‘ƒ CreateCard µƒ ‰»Î ¬º˛
        ShopUI.ExchangeTime += ShopUI_ExchangeTime;
        ShopUI.ExchangeCreation += ShopUI_ExchangeCreation;
    }

    private void ShopUI_ExchangeCreation(object sender, EventArgs e)
    {
        createCardcount++;
        PlayerPrefs.SetInt(TIME_CARD_COUNT, createCardcount);
        createMeatText.text = " £”‡£∫" + createCardcount;
    }

    private void ShopUI_ExchangeTime(object sender, EventArgs e)
    {
        timeCardCount++;
        PlayerPrefs.SetInt(TIME_CARD_COUNT, timeCardCount);
        extraTimeText.text = " £”‡£∫" + timeCardCount;
    }

    private void OnUseTimeCard()
    {
        if (timeCardCount <= 0||!GameManager.Instance.IsGamePlaying())
        {
            return;
        }
        UseTimeCard?.Invoke(this, extraTime);
        timeCardCount--;
        PlayerPrefs.SetInt(TIME_CARD_COUNT, timeCardCount);
        extraTimeText.text = " £”‡£∫" + timeCardCount;
    }

    private void OnUseCreateMeatCard()
    {
        if (createCardcount <= 0|| createFoodCounter.GetKitchenObject()!=null||!GameManager.Instance.IsGamePlaying())
        {
            return;
        }
        UseCreateMeatCard?.Invoke(this, EventArgs.Empty);
        createCardcount--;
        PlayerPrefs.SetInt(CREATE_CARD_COUNT, createCardcount);
        createMeatText.text = " £”‡£∫" + createCardcount;
        
    }
    public static void ClearStaticData()
    {
        UseTimeCard = null;
        UseCreateMeatCard  =null;
    }



}
