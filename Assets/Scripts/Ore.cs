using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : MonoBehaviour
{
    public ResourceType type;
    public GameObject byproduct;
    public float smeltingTime = 2;
    public int amount = 1;
    public int byproductAmount = 1;
}
