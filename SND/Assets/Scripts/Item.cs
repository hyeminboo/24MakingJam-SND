using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName;  // 아이템 이름
    public Sprite icon;      // 아이템 이미지
    public string description; // 아이템 설명

    public void Initialize(string name, Sprite itemIcon, string itemDescription)
    {
        itemName = name;
        icon = itemIcon;
        description = itemDescription;
    }
}
