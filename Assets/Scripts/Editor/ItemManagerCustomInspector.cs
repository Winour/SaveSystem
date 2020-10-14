using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ItemManager))]
public class ItemManagerCustomInspector : Editor
{
	public override void OnInspectorGUI()
    {
        ItemManager itemManager = (ItemManager)target;

        DrawDefaultInspector();

        if(GUILayout.Button("Delete Items"))
        {
            itemManager.DeleteItems();
        }
    }
}
