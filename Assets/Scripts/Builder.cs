using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    public GameObject minerPrefab;

    public GameObject cursor;
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            cursor.SetActive(!cursor.activeSelf);
        }

        if (cursor != null)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit))
            {
                cursor.transform.position = hit.point;
                
                if (hit.transform.CompareTag("Crystal"))
                {
                    cursor.GetComponent<Renderer>().material.SetColor("_Color", Color.green);

                    if (Input.GetMouseButtonDown(0))
                    {

                        var miner = Instantiate(minerPrefab, hit.transform.position, Quaternion.identity);
                        miner.GetComponent<AutoMiner>().StartMining(hit.transform.GetComponent<Resource>());

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
