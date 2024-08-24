using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CuttingRecipe
{
    public KitchenObjectSO input;
    public KitchenObjectSO output;
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
[CreateAssetMenu()]
public class CuttingRecipeListSO : ScriptableObject
{
    public List<CuttingRecipe> list;
    private Dictionary<KitchenObjectSO, KitchenObjectSO> recipeDictionary;

    // ������ʱ��ʼ���ֵ�
    private void OnEnable ()
    {
        recipeDictionary = new Dictionary<KitchenObjectSO, KitchenObjectSO>();
        foreach (var recipe in list)
        {
            if (!recipeDictionary.ContainsKey(recipe.input))
            {
                recipeDictionary.Add(recipe.input, recipe.output);
            }
        }
    }

    public KitchenObjectSO GetOutput (KitchenObjectSO input)
    {
        // ʹ���ֵ���п��ٲ���
        if (recipeDictionary.TryGetValue(input, out KitchenObjectSO output))
        {
            return output;
        }
        return null;
    }
}

