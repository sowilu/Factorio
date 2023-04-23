using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaveData
{
    public List<GameObject> enemyTypes;
    public float spawnRate;
    public List<Transform> spawners;
    public int enemyCount;
}
