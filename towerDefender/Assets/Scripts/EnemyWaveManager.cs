using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class EnemyWaveManager : MonoBehaviour
{
    [SerializeField] List<Transform> spawnPoints;
    public event EventHandler OnWaveNumberUpdated;
    float timeForNextWave = 10;

    private float timeCounter;
    int waveNumber;
    Vector3 spawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = spawnPoints[Random.Range(0, spawnPoints.Count)].position;

        timeCounter = timeForNextWave;
        WaveSpawn();
        
    }

    // Update is called once per frame
    void Update()
    {
      timeCounter -= Time.deltaTime;
      if (timeCounter <= 0)
      {
          timeCounter = timeForNextWave;
          WaveSpawn();
      }
    }

    void WaveSpawn()
    {
        int x = 3 + 2 * waveNumber;
        for (int i = 0; i < x; i++)
        {
            Enemy.Create(spawnPosition + UtilsClass.GetRandomDirection() * 3);
        }
        waveNumber++;
        OnWaveNumberUpdated?.Invoke(this, EventArgs.Empty);
        spawnPosition = spawnPoints[Random.Range(0, spawnPoints.Count)].position;
    }

    public Vector3 GetSpawnPosition() => spawnPosition;
    public float GetTimeForNextWave()=> timeCounter;
    public int GetWaveNumber()=> waveNumber;
}
