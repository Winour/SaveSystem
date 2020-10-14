using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemDisplay : MonoBehaviour {

    [SerializeField] private ItemInfo _itemInfo;
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _itemNameDisplay;
    [SerializeField] private TextMeshProUGUI _itemAmmountDisplay;

    void Start () 
	{
        ItemManager.onEraseData += UpdateItemsAmmount;
	}

    public void UpdateItemDisplay()
    {
        _icon.sprite = _itemInfo.itemIcon;
        _itemNameDisplay.text = _itemInfo.itemName;
        UpdateItemsAmmount();
    }
	
    public void ResetItemDisplay()
    {
        _icon.sprite = null;
        _itemNameDisplay.text = "Name";
        _itemAmmountDisplay.text = "99999";
    }

	public void AddItems(int value)
    {
        if(ItemManager.instance.AddItems(_itemInfo.item, value))
            UpdateItemsAmmount();
    }

    private void UpdateItemsAmmount()
    {
        if(ItemManager.instance != null && _itemInfo != null && ItemManager.instance.itemsInProperty.ContainsKey(_itemInfo.item))
            _itemAmmountDisplay.text = ItemManager.instance.itemsInProperty[_itemInfo.item].ToString("G0");
    }
}
