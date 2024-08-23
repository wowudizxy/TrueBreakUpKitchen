using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : KitchenObjectHolder
{
    [SerializeField] private GameObject selectCounter;//被player选中后的counter样子

    public virtual void Interact (Player player)//交互方法
    {
        Debug.LogWarning("Counter子类未书写 Interact 方法");
    }
    public void SelectCounter ()//选中counter
    {
        selectCounter.SetActive(true);
    }
    public void CancelSelect ()//取消选中counter
    {
        selectCounter.SetActive(false);
    }
}
