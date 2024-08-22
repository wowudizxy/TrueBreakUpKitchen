using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private GameObject selectCounter;
    [SerializeField] private GameObject kitchenObjectPrefab;
    [SerializeField] private Transform point;
    public void Interact ()
    {
        GameObject go = Instantiate(kitchenObjectPrefab, point, false);

    }
    public void SelectCounter ()
    {
        selectCounter.SetActive(true);
    }
    public void CancelSelect ()
    {
        selectCounter.SetActive(false);
    }
}
