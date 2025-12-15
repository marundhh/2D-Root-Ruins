using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public Items[] collectableItems;

    private Dictionary<CollectableType, Items> collectableItemsDict = new Dictionary<CollectableType, Items>();
    
    private void Awake()
    {
        foreach (Items item in collectableItems)
        {
            AddItem(item);
        }
    }
    private void AddItem(Items item)
    {
        if (!collectableItemsDict.ContainsKey(item.type))
        {
            collectableItemsDict.Add(item.type, item);
        }
    }
    public Items GetItemByType(CollectableType type)
    {
        if (collectableItemsDict.ContainsKey(type))
        {
            return collectableItemsDict[type];
        }
        return null;
    }
}
