using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class KitchenObjectHolder : MonoBehaviour
{
    private KitchenObject kitchenObject;//拥有的食材
    [SerializeField] private Transform holdPoint;//放置食材的坐标
    //转移食材方法：原持有者->目标持有者
    public void TransferKitchenObject (KitchenObjectHolder sourceHolder, KitchenObjectHolder targetHolder)
    {
        if (sourceHolder.GetKitchenObject() == null)
        {
            Debug.LogWarning("原持有者上没有食物");
            return;
        }
        if (targetHolder.GetKitchenObject() != null)
        {
            Debug.LogWarning("目标持有者上有食物");
            return;
        }
        targetHolder.AddKitchenObject(sourceHolder.GetKitchenObject());
        ClearKitchenObject();
    }
    //添加参数食材到指定地点，并将新食材赋值给本身的kitchenObject
    private void AddKitchenObject (KitchenObject kitchenObject)
    {
        kitchenObject.transform.SetParent(holdPoint, false);
        SetKitchenObject(kitchenObject);
    }
    //取得食材
    public KitchenObject GetKitchenObject ()
    {
        return kitchenObject;
    }
    //取得放置食材坐标
    public Transform GetHoldPoint ()
    {
        return holdPoint;
    }
    //清空本身kitchenObject
    private void ClearKitchenObject ()
    {
        kitchenObject = null;
    }
    //更新本身食材
    public void SetKitchenObject (KitchenObject kitchenObject)
    {
        print(gameObject);
        this.kitchenObject = kitchenObject;
    }
    //判断本身是否有食材
    public bool IsHaveKitchenObject ()
    {
        return kitchenObject != null;
    }
}
