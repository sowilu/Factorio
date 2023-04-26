using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMiner : MonoBehaviour
{
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
            stash++;
            notificationImage.ShowImage(resource.icon);
            resource.amount--;
        }
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
