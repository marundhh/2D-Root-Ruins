using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

using UnityEngine;
using UnityEngine.U2D;

[System.Serializable]
public class Inventory 
{
    [System.Serializable]
    public class Slot
    {
        public CollectableType type;
        public int count;
        public int maxAllowed;

        public Sprite icon;

       
        [SerializeField] public Slot()
        {
            type = CollectableType.NONE;
            count = 0;
            maxAllowed = 64;
        }

        public bool CanAddItem()
        {
            if (count < maxAllowed)
            {
                return true;
            }
            return false;
        }
        public void AddItem(Items item)
        {
            this.type = item.type;
            this.icon = item.icon;
            count++;
        }
        public void AddItemBuy( Sprite sprite, CollectableType type)
        {
            this.type = type;
            this.icon = sprite;
            count++;
        }
        public void RemoveItem()
        {
            if (count > 0)
            {
                count--;
                if (count == 0)
                {
                    icon = null;
                    type = CollectableType.NONE;
                }
            }
        }
    }
    public List<Slot> slots = new List<Slot>();
    public Inventory(int numSlots)
    {
        for (int i = 0; i < numSlots; i++)
        {
           Slot slot = new Slot();
            slots.Add(slot);
        }
    }
    public void Add(Items item)
    {
        foreach (Slot slot in slots)
        {
            if(slot.type == item.type && slot.CanAddItem())
            {
                slot.AddItem(item);
                return;
            }
        }
        foreach (Slot slot in slots)
        {
            if (slot.type == CollectableType.NONE)
            {
                slot.AddItem(item);
                return;
            }
        }
    }
    public void AddBuy(Sprite sprite, CollectableType type)
    {
        foreach (Slot slot in slots)
        {
            if (slot.type ==type && slot.CanAddItem())
            {
                slot.AddItemBuy(sprite, type);
                return;
            }
        }
        foreach (Slot slot in slots)
        {
            if (slot.type == CollectableType.NONE)
            {
                slot.AddItemBuy(sprite, type);
                return;
            }
        }
    }
    public void Sell(Sprite sprite, CollectableType type)
    {
        foreach (Slot slot in slots)
        {
            if (slot.type == type && slot.CanAddItem())
            {
                slot.AddItemBuy(sprite, type);
                return;
            }
        }
        foreach (Slot slot in slots)
        {
            if (slot.type == CollectableType.NONE)
            {
                slot.AddItemBuy(sprite, type);
                return;
            }
        }
    }
    public void Remove(int index)
    {
        slots[index].RemoveItem();
    }

    int countItems = 0;
    public int GetItem(CollectableType type)
    {
        countItems = 0;
        foreach (Slot slot in slots)
        {
            if (slot.type == type)
            {
                countItems = countItems + slot.count;
            }
          
        } return countItems;  
    }
    int index;
    public int getSlots(CollectableType type)
    {
        index = 0;
        foreach (Slot slot in slots)
        {
            if ((slot.type == type))
            {
                Debug.Log("invent" + slot.type +"  da"+ type);
                 index = slots.IndexOf(slot);
            } 
        }
        return index;
       
    }
}
