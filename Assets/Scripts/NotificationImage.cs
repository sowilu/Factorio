using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class NotificationImage : MonoBehaviour
{
    private Image image;
    private void Start()
    {
        image = GetComponent<Image>();
        image.enabled = false;
    }

    public void ShowImage(Sprite sprite)
    {
        image.sprite = sprite;
        image.enabled = true;
    }
    
    public void HideImage()
    {
        image.enabled = false;
    }
    
}
