using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem {

    private static string itemsArchiveName = "/items.drl";

    public static void SaveItems(ItemManager itemManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + itemsArchiveName;
        FileStream stream = new FileStream(path, FileMode.Create);

        ItemsData data = new ItemsData(itemManager);

        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log("Items saved. Awesome!");
    }

    public static ItemsData LoadItems()
    {
        string path = Application.persistentDataPath + itemsArchiveName;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ItemsData data = formatter.Deserialize(stream) as ItemsData;
            stream.Close();
            Debug.Log("Items loaded. Super!");
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static void DeleteItems()
    {
        File.Delete(Application.persistentDataPath + itemsArchiveName);
    }

}
