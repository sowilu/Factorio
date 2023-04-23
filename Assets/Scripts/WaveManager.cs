using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class WaveManager : MonoBehaviour
{
    public List<WaveData> waves;
    public float timeBetween = 10;
    public float headStart = 15;
    
    public UnityEvent<int> onWaveStart;
    public UnityEvent<int> onWaveEnd;
    
    int currentWave = 0;

    private void Start()
    {
        StartCoroutine(MakeWaves());
    }

    IEnumerator MakeWaves()
    {
        
        yield return new WaitForSeconds(headStart);
        
        while (currentWave < waves.Count)
        {
            yield return StartCoroutine(SpawnEnemies());
            currentWave++;
            yield return new WaitForSeconds(timeBetween);
        }
    }
    
    IEnumerator SpawnEnemies()
    {
        onWaveStart.Invoke(currentWave + 1);
        print("Wave " + (currentWave + 1) + " started!");
        
        while (waves[currentWave].enemyCount > 0)
        {
            var enemy = waves[currentWave].enemyTypes[Random.Range(0, waves[currentWave].enemyTypes.Count)];
            var spawner = waves[currentWave].spawners[Random.Range(0, waves[currentWave].spawners.Count)];
            
            Instantiate(enemy, spawner.position, spawner.rotation);
            waves[currentWave].enemyCount--;
            
            yield return new WaitForSeconds(1 / waves[currentWave].spawnRate);
        }
        
        onWaveEnd.Invoke(currentWave + 1);
        print("Wave " + (currentWave + 1) + " ended!");
    }
}
