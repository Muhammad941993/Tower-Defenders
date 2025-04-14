using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] Button PlayButton;
    [SerializeField] Button exitButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        PlayButton.onClick.AddListener(() => { GameSceneManager.Load(GameSceneManager.Scene.Gameplay); });

        exitButton.onClick.AddListener(() => { Application.Quit(); });
    }
}
