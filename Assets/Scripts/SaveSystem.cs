using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem {

    private static string itemsArchiveName = "/items.drl";
    private static string path;
    private static BinaryFormatter formatter;

    static SaveSystem()
    {
        formatter = new BinaryFormatter();
        path = Application.persistentDataPath + itemsArchiveName;
    }

    public static void SaveItems(ItemManager itemManager)
    {
        FileStream stream = new FileStream(path, FileMode.Create);

        ItemsData data = new ItemsData(itemManager);

        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log("Items saved. Awesome!");
    }

    public static ItemsData LoadItems()
    {
        if (File.Exists(path))
        {
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
