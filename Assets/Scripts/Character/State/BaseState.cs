using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    protected State state;
    protected TopDownController controller;

    protected BaseState(TopDownController controller)
    {
        this.controller = controller;
    }

    public State State { get { return state; } }

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
