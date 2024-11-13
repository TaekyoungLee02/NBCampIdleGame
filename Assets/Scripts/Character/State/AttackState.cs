using UnityEngine;
using UnityEngine.Apple;

public class AttackState : BaseState
{
    public AttackState(TopDownController controller) : base(controller)
    {
        state = State.Attack;
    }

    public override void OnStateEnter()
    {
        controller.StartAttack();
    }

    public override void OnStateExit()
    {
        controller.StopAttack();

    }

    public override void OnStateUpdate()
    {

    }
}
