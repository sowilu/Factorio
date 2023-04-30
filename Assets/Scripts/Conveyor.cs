using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public float speed = 1;

    private void OnCollisionStay(Collision other)
    {
        //TODO: make this work with any resource
        if (other.transform.CompareTag("Crystal"))
        {
            other.transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
    
}
