using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour {

    public static ItemManager instance;

    public Dictionary<Items, int> itemsInProperty;

    public delegate void UpdateAllUI();
    public static event UpdateAllUI onEraseData;

    public enum Items
    {
        Potion,
        SuperPotion,
        FuryPotion,
        StealthPotion,
        GodPotion
    }

    public Items StringToEnum(string _name)
    {
        switch (_name)
        {
            case "Potion":
                return Items.Potion;
            case "SuperPotion":
                return Items.SuperPotion;
            case "FuryPotion":
                return Items.FuryPotion;
            case "StealthPotion":
                return Items.StealthPotion;
            case "GodPotion":
                return Items.GodPotion;
            default:
                Debug.LogError("The string given does not match with the name of an Item");
                return Items.Potion;
        }
    }

	void Awake () 
	{
		if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        if (PlayerPrefs.GetInt("FirstRun") == 0)
        {
            Debug.Log("First time running this App. Nice! Let's create your saved items file.");
            FirstSave();
        }
        else
        {
            Debug.Log("Attempting to load all your items.");
            LoadItems();
        }
    }

    public void LoadItems()
    {
        ItemsData data = SaveSystem.LoadItems();

        SetUpItemsDictionary();

        for (int i = 0; i < data.itemsInPropertyAmmount.Count; i++)
        {
            itemsInProperty[StringToEnum(data.itemsInPropertyName[i])] = data.itemsInPropertyAmmount[i];
        }
    }

    private void SetUpItemsDictionary()
    {
        itemsInProperty = new Dictionary<Items, int>();
        System.Array itemsList = System.Enum.GetValues(typeof(Items));

        foreach (Items item in itemsList)
        {
            itemsInProperty.Add(item, 0);
        }
    }

    private void FirstSave()
    {
        SetUpItemsDictionary();
        SaveSystem.SaveItems(this);
        PlayerPrefs.SetInt("FirstRun", 1);
    }

    public void SaveItems()
    {
        SaveSystem.SaveItems(this);
        PlayerPrefs.SetInt("FirstRun", 1);
    }

    public void DeleteItems()
    {
        SaveSystem.DeleteItems();
        PlayerPrefs.SetInt("FirstRun", 0);
        SetUpItemsDictionary();
        onEraseData();
        Debug.Log("All the data was erased. WOW!");
    }

    public bool AddItems(Items _item, int _value)
    {
        if(itemsInProperty[_item] + _value >= 0)
        {
            itemsInProperty[_item] += _value;
            return true;
        }
        return false;
    }
}
