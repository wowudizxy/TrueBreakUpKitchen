using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private GameObject selectCounter;
    public void Interact ()
    {
        print(gameObject + "Interected");
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
