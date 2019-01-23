using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemsData
{
    public List<int> itemsInPropertyAmmount;
    public List<string> itemsInPropertyName;

    public ItemsData()
    {
        itemsInPropertyAmmount = new List<int>();
        itemsInPropertyName = new List<string>();
    }

    public ItemsData(ItemManager itemManager)
    {
        System.Array itemsList = System.Enum.GetValues(typeof(ItemManager.Items));

        itemsInPropertyAmmount = new List<int>();
        itemsInPropertyName = new List<string>();

        foreach (ItemManager.Items item in itemsList)
        {
            if(itemManager.itemsInProperty[item] != 0)
            {
                itemsInPropertyName.Add(item.ToString());
                itemsInPropertyAmmount.Add(itemManager.itemsInProperty[item]);
            }
        }
    }
	
}
