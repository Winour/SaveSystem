using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemsData
{
    public ItemManager.Items itemSelected;
    public int[] itemsInProperty;

    public ItemsData()
    {
        System.Array itemsList = System.Enum.GetValues(typeof(ItemManager.Items));
        itemsInProperty = new int[itemsList.Length];
    }

    public ItemsData(ItemManager itemManager)
    {
        itemSelected = itemManager.itemSelected;

        System.Array itemsList = System.Enum.GetValues(typeof(ItemManager.Items));
        itemsInProperty = new int[itemsList.Length];
        foreach (ItemManager.Items item in itemsList)
        {
            itemsInProperty[(int)item] = itemManager.itemsInProperty[item];
        }
    }
	
}
