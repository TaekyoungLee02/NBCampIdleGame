using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class CharacterEquipment : MonoBehaviour
{
    private IEquipable[] equips;

    private void Awake()
    {
        equips = new IEquipable[2];
    }

    public void EquipWeapon(Equipment weapon)
    {
        equips[(int)Equip.Weapon] = weapon;
    }

    public void EquipArmor(Equipment armor)
    {
        equips[(int)Equip.Armor] = armor;
    }

    public int GetItemValue(Equip equip)
    {
        for (int i = 0; i < equips.Length; i++)
        {
            if (equips[i] == null) continue;

            if (equips[i].EquipType == equip)
            {
                return equips[i].GetItemValue();
            }
        }

        return 0;
    }
}

public enum Equip
{
    Weapon,
    Armor
}
