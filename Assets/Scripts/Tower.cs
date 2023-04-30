using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float range = 10;
    public float fireRate = 1f;
    public GameObject bullet;
    public Transform shootingPoint;
    float fireTimer = 0;

    public int bulletCount = 0;
    
    void Update()
    {
        fireTimer -= Time.deltaTime;
        
        GameObject closestEnemy = null;
        float closestDistance = range;

        var hits = Physics.SphereCastAll(transform.position, range, Vector3.up, 0, LayerMask.GetMask("Enemy"));
        
        foreach (var hit in hits)
        {
            //var distance = Vector3.Distance(transform.position, hit.transform.position);
            var distance = hit.distance;
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = hit.transform.gameObject;
            }
        }
        
        if(closestEnemy != null && fireTimer <= 0)
        {
            fireTimer = 1 / fireRate;
            var bulletInstance = Instantiate(bullet, shootingPoint.position, Quaternion.identity);
           bulletInstance.GetComponent<Bullet>().SetTarget(closestEnemy.transform);
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Crystal"))
        {
            bulletCount += 1;
            Destroy(other.gameObject);
        }
    }
}
