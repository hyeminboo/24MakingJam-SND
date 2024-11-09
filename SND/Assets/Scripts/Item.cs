using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;  // 아이템 이름
    public Sprite icon;      // 아이템 이미지
    public string description; // 아이템 설명

    public Item(string name, Sprite itemIcon, string itemDescription)
    {
        itemName = name;
        icon = itemIcon;
        description = itemDescription;
    }
}
