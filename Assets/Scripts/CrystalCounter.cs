using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class CrystalCounter : MonoBehaviour
{
    public static CrystalCounter instance;
    
    public int crystalCount = 0;
    public TextMeshProUGUI crystalCountText;

    [Header("Animation settings")] 
    public float duration = 0.3f;
    public float sizeMultiplier = 1.5f;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    //public add function that tweens the crystal count
    public void AddCrystals(int amount)
    {
        crystalCount += amount;
        crystalCountText.text = crystalCount.ToString();
        crystalCountText.gameObject.transform.DOScale(1, duration).ChangeStartValue(transform.localScale * sizeMultiplier).SetEase(Ease.OutBack);
    }
}
