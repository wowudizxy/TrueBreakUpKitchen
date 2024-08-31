using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
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
            Loader.Load(Loader.Scene.GameLoading);
        });
        endGameBt.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }
}
