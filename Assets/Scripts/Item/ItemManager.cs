using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private List<Item> items;

    private List<IEquipable> equipables = new List<IEquipable>();
    private List<IUseable> useables = new List<IUseable>();

    private void Awake()
    {
        items = Resources.Load<ItemInfo>("Data/Item/ItemInfo").items;

        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].type == ItemType.Potion)
            {
                useables.Add(new Potion(PotionType.Heal, items[i].name, items[i].value));
            }

            else
            {
                if (items[i].type == ItemType.Armor) equipables.Add(new Equipment(Equip.Armor, items[i].name, items[i].value));
                else equipables.Add(new Equipment(Equip.Weapon, items[i].name, items[i].value));
            }
        }
    }
}
