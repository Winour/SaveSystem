using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {

    public static ItemManager instance;

    public Dictionary<Items, int> itemsInProperty;

    public delegate void OnEraseData();
    public static event OnEraseData onEraseData;

    public enum Items
    {
        Potion,
        SuperPotion,
        FuryPotion,
        StealthPotion,
        GodPotion,
        None
    }

    public Items StringToEnum(string name)
    {
        switch (name)
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
                return Items.None;
        }
    }

	void Awake () 
	{
        if(instance == null)
            instance = this;
        else
        {
            Destroy(this);
            return;
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
        onEraseData?.Invoke();
        Debug.Log("All the data was erased. WOW!");
    }

    public bool AddItems(Items item, int value)
    {
        if(itemsInProperty[item] + value >= 0)
        {
            itemsInProperty[item] += value;
            return true;
        }
        return false;
    }
}
