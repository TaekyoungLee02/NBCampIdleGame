using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemInfo", menuName = "ItemInfo")]
public class ItemInfo : ScriptableObject
{
    public List<Item> items;
}

public enum ItemType
{
    Potion,
    Armor,
    Weapon
}

[System.Serializable]
public struct Item
{
    public string name;
    public ItemType type;
    public int value;
}