using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("New Item Info"))]
public class ItemInfo : ScriptableObject {

    public Sprite itemIcon;
    public string itemName;
    public ItemManager.Items item;

}
