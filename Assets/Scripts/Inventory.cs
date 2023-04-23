using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    public static int activeItems = 0;
    [System.Serializable]
    public class Slot
    {
        
        public string itemName;
        public string itemDesc;
        public int count;
        public int maxAllowed;
        public Sprite icon;
        

        public Slot()
        {
            itemName = "";
            count = 0;
            maxAllowed = 99;
        }

        public bool CanAddItem()
        {
            if (count < maxAllowed)
            {
                return true;
            }
            return false;
        }

        public void AddItem(Item item)
        {
            this.itemName = item.data.itemName;
            this.icon = item.data.icon;
            this.itemDesc = item.data.itemDescription;
            count++;
            
            

        }

        public void RemoveItem()
        {
            if (count > 0)
            {
                count--;

                if (count  == 0)
                {
                    this.itemName = "";
                    this.icon = null;
                    this.itemDesc = "";
                }
            }
            
        }
        
    }

    public List<Slot> slots = new List<Slot>();

    public Inventory(int numSlots)
    {
        for(int i = 0; i < numSlots; i++)
        {
            Slot slot = new Slot();
            slots.Add(slot);
        }
    }

    public void Add(Item item)
    {
        activeItems++;
        Debug.Log(activeItems);
        foreach (Slot slot in slots)
        {
            if(slot.itemName == item.data.itemName && slot.CanAddItem())
            {
                slot.AddItem(item);
                return;
            }
        }

        foreach(Slot slot in slots)
        {
            if(slot.itemName == "")
            {
                slot.AddItem(item);
                return;
            }
        }
    }

    public void Remove(Slot slot)
    {
        if (activeItems > 4)
        {
            activeItems = 4;
        }
        activeItems--;
        slot.RemoveItem();
    }

}
