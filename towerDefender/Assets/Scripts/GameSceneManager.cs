using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameSceneManager 
{
    public enum Scene
    {
        Gameplay,
        MainMenu,
    }

    public static void Load(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
