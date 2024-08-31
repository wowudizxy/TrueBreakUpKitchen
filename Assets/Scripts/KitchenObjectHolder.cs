using System;
using UnityEngine;

public class KitchenObjectHolder : MonoBehaviour
{
    public static event EventHandler PickUP;
    public static event EventHandler Drop;
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
    public void AddKitchenObject (KitchenObject kitchenObject)
    {
        kitchenObject.transform.SetParent(holdPoint, false);
        kitchenObject.transform.localPosition = Vector3.zero;
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
    public void ClearKitchenObject ()
    {
        kitchenObject = null;
    }
    //���±���ʳ��
    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        if (this is Player)
        {
            PickUP?.Invoke(this, EventArgs.Empty);
        }
        else if (this is BaseCounter && kitchenObject != null && this.kitchenObject != kitchenObject)
        {
            Drop?.Invoke(this, EventArgs.Empty);
        }

        this.kitchenObject = kitchenObject;
    }

    //�жϱ����Ƿ���ʳ��
    public bool IsHaveKitchenObject ()
    {
        return kitchenObject != null;
    }
    public void CreateKitchenObject (GameObject kitchenObjectPrefab)
    {
        KitchenObject kitchenObject = Instantiate(kitchenObjectPrefab, GetHoldPoint(), false).GetComponent<KitchenObject>();
        this.kitchenObject = kitchenObject;
    }
    //ɾ��ʳ��
    public void DestroyKitchenObject ()
    {
        Destroy(kitchenObject.gameObject);
        ClearKitchenObject();
    }
    /*public bool IsHavePlate()
    {
        GetKitchenObject().TryGetComponent<PlatesCounter>();
    }*/
    public static void ClearStaticData()
    {
        PickUP = null;
        Drop = null;
    }
}
