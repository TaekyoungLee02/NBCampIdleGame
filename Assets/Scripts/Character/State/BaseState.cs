using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    protected Character character;
    protected BaseState(Character character)
    {
        this.character = character; 
    }

    public abstract void OnStateEnter();
    public abstract void OnStateUpdate();
    public abstract void OnStateExit();
}

public enum State
{
    Idle,
    Move,
    Attack
}
