using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ItemDisplay))]
public class ItemDisplayCustomInspector : Editor
{
    public override void OnInspectorGUI()
    {
        ItemDisplay itemDisplay = (ItemDisplay)target;

        DrawDefaultInspector();

        if(GUILayout.Button("Load Item Display"))
        {
            itemDisplay.UpdateItemDisplay();
        }
        if(GUILayout.Button("Unload Item Display"))
        {
            itemDisplay.ResetItemDisplay();
        }
    }
}
