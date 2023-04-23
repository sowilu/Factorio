using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public TextMeshProUGUI amountText;
    public Image image;
    
    public void SetSlot(InventorySlot slot)
    {
        amountText.text = slot.amount.ToString();
        image.sprite = slot.image;
    }
    
    public void AddAmount(int amount)
    {
        amountText.text = amount.ToString();

        amountText.transform.DOScale(Vector3.one, 0.2f).ChangeStartValue(Vector3.zero).SetEase(Ease.InElastic);
    }
}
