using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHp = 100;

    public bool selfDestruct = true;
    public GameObject damageParticles;
    public GameObject deathParticles;
    
    public UnityEvent<int, int> onDamage;
    public UnityEvent onDeath;
    
    private int hp;

    private void Start()
    {
        hp = maxHp;
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        hp = Mathf.Clamp(hp, 0, maxHp);
        
        onDamage.Invoke(damage, hp);
        if(damageParticles != null)
            Instantiate(damageParticles, transform.position, Quaternion.identity);
        
        if(hp == 0)
        {
            onDeath.Invoke();
            
            if(deathParticles != null)
                Instantiate(deathParticles, transform.position, Quaternion.identity);
        }
    }
}
