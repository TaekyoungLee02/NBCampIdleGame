using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    private List<IUseable> useables = new List<IUseable>();

    private CharacterStat stat;

    public List<IUseable> Items = new List<IUseable>();

    private void Awake()
    {
        stat = GetComponent<CharacterStat>();
    }


    public void AddItem(IUseable useable)
    { 
        useables.Add(useable); 
    }

    public void UseItem(int index)
    {
        if (useables[index] == null) return;
        useables[index].Use(stat);
    }
}
