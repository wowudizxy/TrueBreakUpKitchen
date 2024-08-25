using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounterVisual : MonoBehaviour
{
    [SerializeField] private GameObject sizzlingParticles;
    [SerializeField] private GameObject StoveOnVisual;

    public void ShowStoveEffect()
    {
        sizzlingParticles.SetActive(true);
        StoveOnVisual.SetActive(true);
    }
    public void HideStoveEffect()
    {
        sizzlingParticles.SetActive(false);
        StoveOnVisual.SetActive(false);
    }
}
