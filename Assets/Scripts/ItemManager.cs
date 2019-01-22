using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour {

    public static ItemManager instance;

    public Dictionary<Items, int> itemsInProperty;
    public Items itemSelected = Items.Potion;

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
        itemSelected = data.itemSelected;

        itemsInProperty = new Dictionary<Items, int>();
        System.Array itemsList = System.Enum.GetValues(typeof(Items));

        foreach(Items item in itemsList)
        {
            itemsInProperty.Add(item, data.itemsInProperty[(int)item]);
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
}
