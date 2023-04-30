using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    public GameObject minerPrefab;
    public GameObject conveyorPrefab;

    public GameObject cursor;

    private GameObject selectedBuilding;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            selectedBuilding = minerPrefab;
            cursor.SetActive(!cursor.activeSelf);
        }
        else if(Input.GetKeyDown(KeyCode.N))
        {
            selectedBuilding = conveyorPrefab;
            cursor.SetActive(!cursor.activeSelf);
        }

        if (Input.GetMouseButtonDown(1))
        {
            cursor.transform.Rotate(Vector3.up, 90);
        }
        
        if (cursor != null)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit))
            {
                cursor.transform.position = hit.point;
                
                if (hit.transform.CompareTag("Crystal") && selectedBuilding == minerPrefab)
                {
                    cursor.GetComponent<Renderer>().material.SetColor("_Color", Color.green);

                    if (Input.GetMouseButtonDown(0))
                    {
                    
                        var miner = Instantiate(minerPrefab, hit.transform.position, cursor.transform.rotation);
                        miner.GetComponent<AutoMiner>().StartMining(hit.transform.GetComponent<Resource>());

                    }
                }
                else if (hit.transform.CompareTag("Ground") && selectedBuilding == conveyorPrefab)
                {
                    cursor.GetComponent<Renderer>().material.SetColor("_Color", Color.green);

                    if (Input.GetMouseButtonDown(0))
                    {
                        Instantiate(selectedBuilding, hit.point, cursor.transform.rotation);
                    }
                }
                else
                {
                    cursor.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                }
                
            }
        }
    }
}
