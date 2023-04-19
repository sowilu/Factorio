using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Transform health;
    
    public void OnDamage(int damage, int hp)
    {
        health.localScale = new Vector3((float)hp / 100, 1, 1);
    }
}
