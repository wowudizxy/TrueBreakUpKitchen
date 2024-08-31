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

    public static void Load(Scene Target)
    {
        Time.timeScale = 1;
        scene = Target;
        SceneManager.LoadScene((int)Target);
    }
    
}
