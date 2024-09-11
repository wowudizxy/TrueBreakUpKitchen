using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingUI : MonoBehaviour
{
    public const string COIN_COUNT = "CoinCount";
    [SerializeField] private TextMeshProUGUI LoadingSymbol;
    [SerializeField] private int maxDots = 6;
    [SerializeField] private float interval = 0.5f;
    [SerializeField] private TextMeshProUGUI coinCountText;
    [SerializeField] private Button StartBt;
    [SerializeField] private TextMeshProUGUI LoadingText;
    private int coinCount = 0;
    private int Timer = 0;
    private float startTime = 6;

    private void Start()
    {
        coinCount = PlayerPrefs.GetInt(COIN_COUNT, coinCount);
        coinCountText.text = "" + coinCount;
        Food.Foodcaught += OnFoodCaught;
        StartCoroutine(CycleSymbol());
        StartBt.onClick.AddListener(() => Loader.Load(Loader.Scene.GameScene));
    }

    // 优化：取消事件订阅，防止内存泄漏
    private void OnDestroy()
    {
        Food.Foodcaught -= OnFoodCaught;
    }

    private void OnFoodCaught(object sender, System.EventArgs e)
    {
        coinCount += 2;
        coinCountText.text = "" + coinCount;
        PlayerPrefs.SetInt(COIN_COUNT, coinCount);
    }

    IEnumerator CycleSymbol()
    {
        int dotCount = 0;

        while (Timer != startTime)
        {
            Timer++;
            if (Timer == startTime)
            {
                StartBt.gameObject.SetActive(true);
                LoadingText.text = "加载完成";
                LoadingSymbol.gameObject.SetActive(false);
            }
            dotCount = (dotCount % maxDots) + 1;
            LoadingSymbol.text = new string('.', dotCount);
            yield return new WaitForSeconds(interval);
        }
    }
}
