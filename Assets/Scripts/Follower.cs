using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Follower : MonoBehaviour
{
    //follows target smoothly  with same offset as when started
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    
    void Start()
    {
        offset = transform.position - target.position;
    }
    
    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
    
}
