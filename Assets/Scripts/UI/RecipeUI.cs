using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecipeUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI recipeName;
    [SerializeField] private Transform iconList;
    [SerializeField] private Image icon;
    public void UpdateDetailUI(RecipeSO recipeSO)
    {
        recipeName.text = recipeSO.recipeName;
        foreach (KitchenObjectSO item in recipeSO.RecipeObejectList)
        {
            Image newIcon =  Instantiate(icon, iconList);
            newIcon.transform.Find("Image/Sprite").GetComponent<Image>().sprite = item.sprite;
            newIcon.gameObject.SetActive(true);
        }
    }
}
