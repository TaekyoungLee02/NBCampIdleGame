using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterStat : MonoBehaviour
{
    public int maxHP;
    public int curHP;
    public int attack;
    public int defense;

    public void ChangeHealth(int value)
    {
        if(value < 0)
        {
            value += defense;

            if (value >= 0) value = 0;
        }

        curHP += value;

        Mathf.Clamp(curHP, 0, maxHP);

        if(curHP == 0) Destroy(gameObject);
    }
}
