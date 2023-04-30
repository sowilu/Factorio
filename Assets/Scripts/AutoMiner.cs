using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMiner : MonoBehaviour
{
    public float conveyorRange = 3;
    public NotificationImage notificationImage;
    public Resource resource;

    private int stash = 0;
    public void StartMining(Resource resource)
    {
        this.resource = resource;
        StartCoroutine(Mine());
    }

    IEnumerator Mine()
    {
        while(resource.amount > 0)
        {
            yield return new WaitForSeconds(resource.miningTime);
            //Inventory.instance.AddResource(resource.type, 1);
            
            var conveyorPosition = GetConveyorPosition();

            if (conveyorPosition.x == 999)
            {
                stash++; 
                notificationImage.ShowImage(resource.icon);
            }
            else
            {
                Instantiate(resource.prefab, conveyorPosition + Vector3.up, Quaternion.identity);
            }
            resource.amount--;
        }
    }
    
    
    Vector3 GetConveyorPosition()
    {
        var colliders = Physics.OverlapSphere(transform.position, conveyorRange);
        
        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Conveyor"))
            {
                return collider.transform.position;
            }
        }

        return new Vector3(999, 999, 999);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Inventory.instance.AddResource(resource.type, stash);
            stash = 0;
            notificationImage.HideImage();
        }
    }
}
