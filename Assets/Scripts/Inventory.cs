using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct InventorySlot
{
    public ResourceType type;
    public int amount;
    public Sprite image;
    public Slot slot;

    public void AddAmount(int amount)
    {
        this.amount += amount;
        slot.AddAmount(this.amount);
    }
}

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
