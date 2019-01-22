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
    [SerializeField]
    private TextMeshProUGUI itemName;
    [SerializeField]
    private TextMeshProUGUI itemAmmount;

	void Start () 
	{
        itemIcon.sprite = itemInfo.itemIcon;
        itemName.text = itemInfo.itemName;
        itemAmmount.text = ItemManager.instance.itemsInProperty[itemInfo.item].ToString("G0");
        ItemManager.onEraseData += UpdateItems;
	}
	
	public void AddItems(int _value)
    {
        ItemManager.instance.itemsInProperty[itemInfo.item] += _value;
        UpdateItems();
    }

    private void UpdateItems()
    {
        itemAmmount.text = ItemManager.instance.itemsInProperty[itemInfo.item].ToString("G0");
    }
}
