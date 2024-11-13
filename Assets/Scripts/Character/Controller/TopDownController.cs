using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class TopDownController : MonoBehaviour
{
    protected FSM fsm;

    public event Action<Vector3> OnMove;
    public event Action OnAttack;


    public virtual void SetDestination(Vector3 destination)
    {
        OnMove?.Invoke(destination);
    }

    public abstract void StartAttack();
    public abstract void StopAttack();
}
