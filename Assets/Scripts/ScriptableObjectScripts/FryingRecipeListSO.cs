using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class FryingRecipeListSO : ScriptableObject
{
    public List<FryingRecipe> list;
    private Dictionary<KitchenObjectSO, FryingRecipe> recipeDictionary;

    // 在启用时初始化字典
    private void OnEnable()
    {
        recipeDictionary = new Dictionary<KitchenObjectSO, FryingRecipe>();
        foreach (var recipe in list)
        {
            if (!recipeDictionary.ContainsKey(recipe.input))
            {
                recipeDictionary.Add(recipe.input, recipe);
            }
        }
    }

    public bool TryGetFryingRecipe(KitchenObjectSO input, out FryingRecipe inputFryingRecipe)
    {
        if (recipeDictionary.TryGetValue(input, out FryingRecipe fryingRecipe))
        {
            inputFryingRecipe = fryingRecipe;
            return true;
        }
        inputFryingRecipe = null;
        return false;
    }
}
[Serializable]
public class FryingRecipe
{
    public KitchenObjectSO input;
    public KitchenObjectSO output;
    public int fryingTime;
}
