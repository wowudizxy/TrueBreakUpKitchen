using System;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public event EventHandler UpdateOrderRecipe;
    public event EventHandler OnRecipeSuccessed;
    public event EventHandler OnRecipeFailed;
    public static OrderManager Instance { get;private set; }
    [SerializeField] private RecipeListSO recipeSOlist;//总食谱集合
    [SerializeField] private float orderTime=3;
    [SerializeField] private int orderMax = 5;
    private List<RecipeSO> existOrderList = new List<RecipeSO>();//当前存在的食谱
    private float Timer;
    private bool isStartOrder = false;
    private int successOrder = 0;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        GameManager.Instance.OnGamePlayingStarted += GameManager_OnGamePlayingStarted;
    }
    private void OnDestroy()
    {
        GameManager.Instance.OnGamePlayingStarted -= GameManager_OnGamePlayingStarted;
    }

    private void GameManager_OnGamePlayingStarted(object sender, EventArgs e)
    {
        isStartOrder = true;
        CreateRecipe();
    }

    private void Update()
    {
        if (isStartOrder&& existOrderList.Count < orderMax&&GameManager.Instance.IsGamePlaying())
        {
            OrderRecipe();
        }
    }

    private void OrderRecipe()
    {
        Timer += Time.deltaTime;
        if (Timer > orderTime)
        {
            Timer = 0;
            CreateRecipe();
        }
    }

    private void CreateRecipe()
    {
        int randomNumber = UnityEngine.Random.Range(0, recipeSOlist.recipeListSO.Count);
        existOrderList.Add(recipeSOlist.recipeListSO[randomNumber]);
        UpdateOrderRecipe?.Invoke(this, EventArgs.Empty);
        if(existOrderList.Count==5)
        {
            isStartOrder = false;
        }
    }

    public void DeliveryRecipe(PlateKitchenObject plateKitchenObject)
    {
        RecipeSO SuccessRecipe =null;
        foreach (var item in existOrderList)
        {
            if (isSuccess(item.RecipeObejectList, plateKitchenObject.GetOnPlateKitchenListSO()))
            {
                SuccessRecipe = item;
                break;
            }
        }
        if (SuccessRecipe == null)
        {
            print("失败");
            OnRecipeFailed?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            successOrder++;
            print("成功");
            existOrderList.Remove(SuccessRecipe);
            UpdateOrderRecipe?.Invoke(this, EventArgs.Empty);
            OnRecipeSuccessed?.Invoke(this, EventArgs.Empty);
        }
    }

    /*private bool isSuccess(List<KitchenObjectSO> list1, List<KitchenObjectSO> list2)
    {
        if(list1.Count!= list2.Count)
        {
            return false;
        }
        foreach (var item in list2)
        {
            if (!list1.Contains(item))
            {
                return false;
            }
        }
        return true;
    }*/
    /*private bool isSuccess(List<KitchenObjectSO> list1, List<KitchenObjectSO> list2)
    {
        if (list1.Count != list2.Count)
        {
            return false;
        }

        list1.Sort((x, y) => x.name.CompareTo(y.name)); // 根据名称或唯一标识符排序
        list2.Sort((x, y) => x.name.CompareTo(y.name));

        return list1.SequenceEqual(list2);
    }*/
    private bool isSuccess(List<KitchenObjectSO> list1, List<KitchenObjectSO> list2)
    {
        if (list1.Count != list2.Count)
        {
            return false;
        }

        HashSet<KitchenObjectSO> set1 = new HashSet<KitchenObjectSO>(list1);
        HashSet<KitchenObjectSO> set2 = new HashSet<KitchenObjectSO>(list2);

        return set1.SetEquals(set2);
    }
    public List<RecipeSO> GetExistOrderList()
    {
        return existOrderList;
    }
    public int GetSuccessOrder()
    {
        return successOrder;
    }

}
