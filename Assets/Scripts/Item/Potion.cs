using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : IUseable
{
    private string potionName;
    private int value;
    private PotionType type;

    public Potion(PotionType type, string name, int value) 
    {
        this.type = type;
        potionName = name;
        this.value = value;
    }

    public string PotionName { get { return potionName; } }
    public PotionType PotionType { get { return type; } }

    string IUseable.GetName()
    {
        return potionName;
    }

    void IUseable.Use(CharacterStat stat)
    {
        stat.ChangeHealth(value);
    }
}

public enum PotionType
{
    Heal,
    Attack
}