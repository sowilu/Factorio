using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool alwaysHit = true;
    public float speed = 10;
    public int damage = 20;
    
    private Transform target;
    private string targetTag = "Enemy";
    
    public void SetTarget(Transform target)
    {
        this.target = target;
        targetTag = target.tag;
        
        //rotate towards target
        transform.LookAt(target);
    }

    
    void Update()
    {
        if (alwaysHit)
        {
            transform.LookAt(target);
        }
        
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag(targetTag))
        {
            target.gameObject.GetComponent<Health>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
