using System;
using UnityEngine;
using UnityEngine.UI;

public class ItemCardUI : MonoBehaviour
{
    public static event EventHandler<int> UseTimeCard; // 使用泛型事件来传递增加的时间
    public static event EventHandler UseCreatMeatCard;
    private int extraTime = 5; // 设置增加的时间为5秒
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
