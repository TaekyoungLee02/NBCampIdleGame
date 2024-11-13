using UnityEngine;
using UnityEngine.Apple;

public class MoveState : BaseState
{
    public MoveState(TopDownController controller) : base(controller)
    {
        state = State.Move;
    }

    public override void OnStateEnter()
    {
        
    }

    public override void OnStateExit()
    {
        
    }

    public override void OnStateUpdate()
    {
        if (controller is PlayerController) (controller as PlayerController).ChaseEnemy();
    }
}
