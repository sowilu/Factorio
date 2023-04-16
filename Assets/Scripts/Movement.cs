using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public int gridIncrement = 1;
    public float rotationSpeed = 5f;
    public int heightAboveGround = 5;
    public LayerMask groundMask;
    
    private RaycastHit hitInfo;
    
    private void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        
        //check if input
        if (horizontal != 0 || vertical != 0)
        {
            var direction = new Vector3(horizontal, 0, vertical).normalized;
            
            //rotate
            var lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
            
            //move
            var newPosition = transform.position + direction * gridIncrement * speed * Time.deltaTime;
            
            //hover above ground
            if(Physics.Raycast(newPosition, Vector3.down, out hitInfo, heightAboveGround + 1, groundMask))
            {
                newPosition.y = hitInfo.point.y + heightAboveGround;
                transform.position = newPosition;
                
                var surfaceNormal = hitInfo.normal; // Assign the normal of the surface to surfaceNormal
                var forwardRelativeToSurfaceNormal = Vector3.Cross(transform.right, surfaceNormal);
                Quaternion targetRotation = Quaternion.LookRotation(forwardRelativeToSurfaceNormal, surfaceNormal); //check For target Rotation.
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 5f);

            }
        }
        else
        {
            var position = transform.position;
            
            position.x = Mathf.Ceil(position.x);
            position.z = Mathf.Ceil(position.z);
            
            transform.position = position;
        }
    }
}
