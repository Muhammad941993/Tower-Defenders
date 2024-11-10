using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyWaveUI : MonoBehaviour
{
    [SerializeField] private EnemyWaveManager waveManager;
    [SerializeField] private TextMeshProUGUI waveNumber;
    [SerializeField] private RectTransform indicatorTransform;

    [SerializeField] private TextMeshProUGUI waveMessage;
    Camera mainCamera;
    private Vector3 spawnPosition;

    private float time;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        waveManager.OnWaveNumberUpdated += UpdateWaveNumber;
        waveNumber.text = waveManager.GetWaveNumber().ToString();

    }

    private void OnDestroy()
    {
        waveManager.OnWaveNumberUpdated -= UpdateWaveNumber;
    }

    private void UpdateWaveNumber(object sender, EventArgs e)
    {
        waveNumber.text = waveManager.GetWaveNumber().ToString();

    }

    // Update is called once per frame
    void Update()
    {
        time = waveManager.GetTimeForNextWave();
        if (time > 0)
        {
            UpdateWaveMessage($"Time For Next Wave: {time:F1} seconds");
        }
        else
        {
            UpdateWaveMessage("");
        }

        spawnPosition = (waveManager.GetSpawnPosition() - mainCamera.transform.position).normalized;
        indicatorTransform.anchoredPosition = spawnPosition * 200;
        indicatorTransform.eulerAngles = new Vector3(0, 0, UtilsClass.GetAngleFromVector(spawnPosition));
        
        float distanceToIndicator = Vector3.Distance(waveManager.GetSpawnPosition(), mainCamera.transform.position);
        indicatorTransform.gameObject.SetActive(distanceToIndicator > mainCamera.orthographicSize);
    }

    void UpdateWaveMessage(string message)
    {
        waveMessage.text = message;
    }

}
