using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Laser : MonoBehaviour
{
    public float miningDuration = 2f;
    public LineRenderer lineRenderer;
    public Transform sparks;
    public Transform miningSparks;
    public ParticleSystem crystalParticles;
    
    private Camera mainCamera;
    private float miningStart = -1;
    private bool isMining = false;
    
    private void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isMining = true;
            lineRenderer.enabled = true;
            sparks.gameObject.SetActive(true);
            StartCoroutine(Flicker());
        }
        else if(Input.GetMouseButtonUp(0))
        {
            lineRenderer.enabled = false;
            miningStart = -1;
            isMining = false;
            sparks.gameObject.SetActive(false);
            miningSparks.gameObject.SetActive(false);
        }

        if (miningStart != -1 && Time.time - miningStart > miningDuration)
        {
            miningStart = Time.time;
            crystalParticles.Play();
            Inventory.instance.AddResource(ResourceType.Crystal, 1);
        }


        if (isMining)
        {
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit))
            {
                if (hit.transform.CompareTag("Crystal"))
                {
                    if (miningStart == -1)
                    {
                        miningStart = Time.time;
                        miningDuration = hit.transform.GetComponent<Resource>().miningTime;
                    }
                        
                    
                    miningSparks.position = hit.point;
                    crystalParticles.transform.position = hit.point;
                    miningSparks.gameObject.SetActive(true);
                }
                else
                {
                    miningSparks.gameObject.SetActive(false);
                    miningStart = -1;
                }
                    
                lineRenderer.enabled = true;
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, hit.point);
                
                sparks.position = hit.point;
            }
        }
        
    }

    IEnumerator Flicker()
    {
        while (isMining)
        {
            lineRenderer.enabled = true;
            yield return new WaitForSeconds(Random.Range(0.1f, 0.2f));
            lineRenderer.enabled = false;
            yield return new WaitForSeconds(Random.Range(0.1f, 0.2f));
        }
    }
}
