using System;
using UnityEngine;
using UnityEngine.UI;

public class ItemCardUI : MonoBehaviour
{
    public static event EventHandler<int> UseTimeCard; // ʹ�÷����¼����������ӵ�ʱ��
    public static event EventHandler UseCreatMeatCard;
    private int extraTime = 5; // �������ӵ�ʱ��Ϊ5��
    [SerializeField] private Button extraTimeBt;
    [SerializeField] private Button createMeatBt;

    private void Start()
    {
        extraTimeBt.onClick.AddListener(() =>
        {
            UseTimeCard?.Invoke(this, extraTime);
        });
        createMeatBt.onClick.AddListener(() =>
        {
            UseCreatMeatCard?.Invoke(this, EventArgs.Empty);
        });
    }
}
