using UnityEngine;
using UnityEngine.Apple;

public class IdleState : BaseState
{
    public IdleState(TopDownController controller) : base(controller)
    {
        state = State.Idle;
    }

    public override void OnStateEnter()
    {
        
    }

    public override void OnStateExit()
    {
        
    }

    public override void OnStateUpdate()
    {
        controller.SetDestination(controller.transform.forward);
    }
}
