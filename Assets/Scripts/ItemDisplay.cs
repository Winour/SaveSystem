using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemDisplay : MonoBehaviour {

    [SerializeField]
    private ItemInfo itemInfo;
    [SerializeField]
    private Image itemIcon;
#pragma warning disable 649  
    [SerializeField]
    private TextMeshProUGUI itemName, itemAmmount;
#pragma warning restore 649

    void Start () 
	{
        itemIcon.sprite = itemInfo.itemIcon;
        itemName.text = itemInfo.itemName;
        itemAmmount.text = ItemManager.instance.itemsInProperty[itemInfo.item].ToString("G0");
        ItemManager.onEraseData += UpdateItems;
	}
	
	public void AddItems(int _value)
    {
        if (ItemManager.instance.AddItems(itemInfo.item, _value))
        {
            UpdateItems();
        }
    }

    private void UpdateItems()
    {
        itemAmmount.text = ItemManager.instance.itemsInProperty[itemInfo.item].ToString("G0");
    }
}
