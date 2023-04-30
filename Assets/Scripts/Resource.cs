using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceType{
    Crystal,
    Coal,
    Copper,
    Iron
}

public class Resource : MonoBehaviour
{
    public GameObject prefab;
    public Sprite icon;
    public ResourceType type;
    public int amount = 1000;
    public float miningTime = 1;
    
}
