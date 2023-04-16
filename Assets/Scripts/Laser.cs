using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public int crystalCount = 0;
    public float miningDuration = 2f;
    public LineRenderer lineRenderer;

    private Camera mainCamera;
    private float miningStart = -1;
    
    private void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit))
            {
                miningStart = Time.time;
                lineRenderer.enabled = true;
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, hit.point);
            }
        }
        else if(Input.GetMouseButtonUp(0))
        {
            lineRenderer.enabled = false;
        }

        if (miningStart != -1 && Time.time - miningStart > miningDuration)
        {
            miningStart = -1;
            crystalCount++;
        }

    }
}
