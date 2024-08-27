using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderListUI : MonoBehaviour
{
    [SerializeField] private RecipeUI recipeTempUI;
    [SerializeField] private Transform recipeList; 
    private void Start()
    {
        OrderManager.Instance.HaveNewOrderRecipe += Instance_HaveNewOrderRecipe;
    }

    private void Instance_HaveNewOrderRecipe(object sender, System.EventArgs e)
    {
        UpdateOrderList(OrderManager.Instance.GetExistOrderList());
    }

    private void UpdateOrderList(List<RecipeSO> existOrderList)
    {
        foreach (Transform item in recipeList)
        {
            if(item!= recipeTempUI.transform)
            {
                Destroy(item.gameObject);
            }
        }
        foreach (RecipeSO recipeSO in existOrderList)
        {
            RecipeUI recipeUI =  Instantiate(recipeTempUI, recipeList);
            recipeUI.gameObject.SetActive(true);
        }
    }
}
