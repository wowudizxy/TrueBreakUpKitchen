using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenuUI : MonoBehaviour
{
    [SerializeField] private Button startGameBt;
    [SerializeField] private Button endGameBt;

    private void Start()
    {
        startGameBt.onClick.AddListener(() =>
        {

        });
        endGameBt.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }
}
