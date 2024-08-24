using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CuttingRecipe
{
    public KitchenObjectSO input;
    public KitchenObjectSO output;
    public int cuttingCount;
}

[CreateAssetMenu()]
public class CuttingRecipeListSO : ScriptableObject
{
    public List<CuttingRecipe> list;
    private Dictionary<KitchenObjectSO, CuttingRecipe> recipeDictionary;

    // 在启用时初始化字典
    private void OnEnable ()
    {
        recipeDictionary = new Dictionary<KitchenObjectSO, CuttingRecipe>();
        foreach (var recipe in list)
        {
            if (!recipeDictionary.ContainsKey(recipe.input))
            {
                recipeDictionary.Add(recipe.input, recipe);
            }
        }
    }

    public bool TryGetCuttingRecipe(KitchenObjectSO input,out CuttingRecipe inputCuttingRecipe)
    {
        if (recipeDictionary.TryGetValue(input, out CuttingRecipe cuttingRecipe))
        {
            inputCuttingRecipe = cuttingRecipe;
            return true;
        }
        inputCuttingRecipe=null;
        return false;
    }
    /*[CreateAssetMenu()]
    public class CuttingRecipeListSO : ScriptableObject
    {
        public List<CuttingRecipe> list;

        public KitchenObjectSO GetOutput (KitchenObjectSO input)
        {
            foreach (var recipe in list)
            {
                if(input == recipe.input)
                {
                    return recipe.output;
                }
            }
            return null;
        }
    }*/
}

