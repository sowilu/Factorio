using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smelter : MonoBehaviour
{
    private Dictionary<Ore, int> ores = new();
    private Dictionary<Ore, int> bars = new();
    
    public float conveyorRange = 3;

    private void Start()
    {
        StartCoroutine(SmeltOres());
    }

    IEnumerator SmeltOres()
    {
        while (true)
        {
            if (ores.Count == 0)
            {
                yield return new WaitForEndOfFrame();
            }
            
            foreach (var ore in ores)
            {

                if(ore.Key.byproductAmount <= ore.Value)
                {
                    print("Smelting " + ore.Key.name + "...");
                    yield return new WaitForSeconds(ore.Key.smeltingTime);

                    var pos = GetConveyorPosition();

                    if (pos.x != 999)
                    {
                        Instantiate(ore.Key.byproduct, pos + Vector3.up, Quaternion.identity);
                        ores[ore.Key] -= ore.Key.byproductAmount;
                    }
                    else
                    {
                        print("No conveyor found, adding to stash...");
                        if (bars.ContainsKey(ore.Key))
                        {
                            bars[ore.Key] += 1;
                        }
                        else
                        {
                            bars.Add(ore.Key, 1);
                        }
                    }
                }
                else
                {
                    yield return new WaitForEndOfFrame();
                }
            }
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
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Crystal"))
        {
            var ore = other.gameObject.GetComponent<Ore>();
            
            //check if ore type is already contained in ores
            if (ores.ContainsKey(ore))
            {
                ores[ore] += ore.amount;
                print("Ores added: " + ores[ore]);
            }
            else
            {
                ores.Add(ore, ore.amount);
                print("New ore added: " + ores[ore]);
            }
            
            Destroy(other.gameObject);
        }
    }
}
