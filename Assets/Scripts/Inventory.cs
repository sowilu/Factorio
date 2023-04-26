using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventorySlot
{
    public ResourceType type;
    public int amount;
    public Sprite image;
    public Slot slot;

    public void AddAmount(int amount)
    {
        this.amount += amount;
        slot.DisplayAmount(this.amount);
    }
}

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    
    public Slot slotPrefab;
    public List<InventorySlot> slots;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        for(int i=0; i<slots.Count; i++)
        {
            slots[i].slot = Instantiate(slotPrefab, transform);
            slots[i].slot.SetSlot(slots[i]);
        }
    }

    public void AddResource(ResourceType type, int amount)
    {
        for(int i=0; i<slots.Count; i++)
        {
            if(slots[i].type == type)
            {
                slots[i].AddAmount(amount);
                return;
            }
        }
    }
}
