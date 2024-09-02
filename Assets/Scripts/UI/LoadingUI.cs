using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingUI : MonoBehaviour
{
    public const string COIN_COUNT = "CoinCount";
    [SerializeField] private TextMeshProUGUI LoadingSymbol;
    [SerializeField] private int maxDots = 6; // ���ĵ���
    [SerializeField] private float interval = 0.5f; // ÿ����֮���ʱ����
    [SerializeField] private TextMeshProUGUI coinCountText;
    [SerializeField] private Button StartBt;
    [SerializeField] private TextMeshProUGUI LoadingText;
    int coinCount = 0;
    int Timer = 0;
    float startTime = 6;
    private void Start()
    {
        coinCount = PlayerPrefs.GetInt(COIN_COUNT, coinCount);
        coinCountText.text = "" + coinCount;
        Food.Foodcaught += Food_Foodcaught;
        StartCoroutine(CycleSymbol());
        StartBt.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.GameScene);
        });
    }

    private void Food_Foodcaught(object sender, System.EventArgs e)
    {
        coinCount++;
        coinCountText.text = "" + coinCount;
        PlayerPrefs.SetInt(COIN_COUNT, coinCount);
    }

    IEnumerator CycleSymbol()
    {
        int dotCount = 0;

        while (Timer!=startTime)
        {
            Timer++;
            if (Timer == startTime)
            {
                StartBt.gameObject.SetActive(true);
                LoadingText.text = "�������";
                LoadingSymbol.gameObject.SetActive(false);
            }
            dotCount = (dotCount % maxDots) + 1; // ���㵱ǰ�ĵ���
            LoadingSymbol.text = new string('.', dotCount); // ���ݵ��������ַ���
            yield return new WaitForSeconds(interval); // �ȴ����ʱ��
        }
    }
}
