using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    private TopDownController controller;
    private CharacterStat stat;
    private CharacterMovement movement;
    private CharacterInventory inventory;

    public TopDownController Controller { get { return controller; } }
    public CharacterStat Stat { get { return stat; } }
    public CharacterMovement Movement { get { return movement; } }
    public CharacterInventory Inventory { get { return inventory; } }


    private void Awake()
    {
        controller = GetComponent<TopDownController>();
        stat = GetComponent<CharacterStat>();
        movement = GetComponent<CharacterMovement>();
        inventory = GetComponent<CharacterInventory>();
    }
}
