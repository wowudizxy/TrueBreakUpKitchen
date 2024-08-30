using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader 
{
    public enum Scene
    {
        GameMenu,
        GameLoading,
        GameScene
    }

    private static Scene scene;

    public static void LoadingScene(Scene Target)
    {
        scene = Target;
        SceneManager.LoadScene((int)Scene.GameLoading);
    }
    public static void LoadBack()
    {
        SceneManager.LoadScene((int)Scene.GameScene);
    }
}
