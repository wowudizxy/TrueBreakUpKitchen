using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class KitchenObjectHolder : MonoBehaviour
{
    private KitchenObject kitchenObject;//ӵ�е�ʳ��
    [SerializeField] private Transform holdPoint;//����ʳ�ĵ�����
    //ת��ʳ�ķ�����ԭ������->Ŀ�������
    public void TransferKitchenObject (KitchenObjectHolder sourceHolder, KitchenObjectHolder targetHolder)
    {
        if (sourceHolder.GetKitchenObject() == null)
        {
            Debug.LogWarning("ԭ��������û��ʳ��");
            return;
        }
        if (targetHolder.GetKitchenObject() != null)
        {
            Debug.LogWarning("Ŀ�����������ʳ��");
            return;
        }
        targetHolder.AddKitchenObject(sourceHolder.GetKitchenObject());
        sourceHolder.ClearKitchenObject();
    }
    //��Ӳ���ʳ�ĵ�ָ���ص㣬������ʳ�ĸ�ֵ�������kitchenObject
    private void AddKitchenObject (KitchenObject kitchenObject)
    {
        kitchenObject.transform.SetParent(holdPoint, false);
        SetKitchenObject(kitchenObject);
    }
    //ȡ��ʳ��
    public KitchenObject GetKitchenObject ()
    {
        return kitchenObject;
    }
    //ȡ�÷���ʳ������
    public Transform GetHoldPoint ()
    {
        return holdPoint;
    }
    //��ձ���kitchenObject
    private void ClearKitchenObject ()
    {
        kitchenObject = null;
    }
    //���±���ʳ��
    public void SetKitchenObject (KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }
    //�жϱ����Ƿ���ʳ��
    public bool IsHaveKitchenObject ()
    {
        return kitchenObject != null;
    }
}
