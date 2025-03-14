using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public static GameOverUI Instance {get; private set;}
    [SerializeField] Button _retrybutton;
    [SerializeField] Button _menubutton;
    [SerializeField] TextMeshProUGUI waveNumberText;

    private void Awake()
    {
        Instance = this;
        _retrybutton.onClick.AddListener(() =>
        {
            GameSceneManager.Load(GameSceneManager.Scene.Gameplay);
        });
        _menubutton.onClick.AddListener(() =>
        {
            GameSceneManager.Load(GameSceneManager.Scene.MainMenu);
        });
        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
        waveNumberText.text = $"You Survived {EnemyWaveManager.Instance.GetWaveNumber()} Waves!";
    }
    void Hide()
    {
        gameObject.SetActive(false);
    }
    
}
