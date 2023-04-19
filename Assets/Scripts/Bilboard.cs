using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bilboard : MonoBehaviour
{
    //always rotate towards the camera
    void Update()
    {
        transform.LookAt(Camera.main.transform);
    }
}
