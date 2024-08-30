using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI LoadingSymbol;
    [SerializeField] private int maxDots = 6; // ���ĵ���
    [SerializeField] private float interval = 0.5f; // ÿ����֮���ʱ����
    [SerializeField] private TextMeshProUGUI coinCountText;
    [SerializeField] private Button StartBt;
    [SerializeField] private TextMeshProUGUI LoadingText;
    int coinCount = 0;
    int count = 0;
    float startTime = 24;
    private void Start()
    {
        Food.Foodcaught += Food_Foodcaught;
        StartCoroutine(CycleSymbol());
        StartBt.onClick.AddListener(() =>
        {
            Loader.LoadBack();
        });
    }

    private void Food_Foodcaught(object sender, System.EventArgs e)
    {
        coinCount++;
        coinCountText.text = "" + coinCount;
    }

    IEnumerator CycleSymbol()
    {
        int dotCount = 0;

        while (count!=startTime)
        {
            count++;
            if (count == startTime)
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
