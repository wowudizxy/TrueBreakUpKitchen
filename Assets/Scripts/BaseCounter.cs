using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : KitchenObjectHolder
{
    [SerializeField] private GameObject selectCounter;//��playerѡ�к��counter����

    public virtual void Interact (Player player)//��������
    {
        Debug.LogWarning("Counter����δ��д Interact ����");
    }
    public void SelectCounter ()//ѡ��counter
    {
        selectCounter.SetActive(true);
    }
    public void CancelSelect ()//ȡ��ѡ��counter
    {
        selectCounter.SetActive(false);
    }
}
