using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    public float cooldown = 1;
    public float range = 5;
    public GameObject bullet;
    
    private Transform target;
    private NavMeshAgent agent;
    private float lastShot = 0;
    
    
    void Start()
    {
        //find object named Base
        target = GameObject.Find("Base").GetComponent<Transform>();

        agent = GetComponent<NavMeshAgent>();
    }
    
    void Update()
    {
        if(target != null)
            agent.SetDestination(target.position);


        if (Time.time - lastShot >= cooldown)
        {
            var buildings = FindBuildingsInRange();
            print(buildings.Count);
            
            var target = FindNearest(buildings);
            
            if (target != null)
            {
                var bulletInstance = Instantiate(bullet, transform.position, Quaternion.identity);
                bulletInstance.GetComponent<Bullet>().SetTarget(target);
                lastShot = Time.time;
            }
        }
    }

    Transform FindNearest(List<Transform> buildings)
    {
        var distance = Mathf.Infinity;
        Transform nearest = null;
        
        foreach (var building in buildings)
        {
            var currentDistance = Vector3.Distance(transform.position, building.position);
            if (currentDistance < distance)
            {
                distance = currentDistance;
                nearest = building;
            }
        }
        
        return nearest;
    }
    
    List<Transform> FindBuildingsInRange()
    {
        var colliders = Physics.OverlapSphere(transform.position, range);
        var buildings = new List<Transform>();

        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Building"))
            {
                buildings.Add(collider.transform);
            }
        }

        return buildings;
    }
}
