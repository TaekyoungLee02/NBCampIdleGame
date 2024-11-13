using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM
{
    private BaseState curState;

    public FSM(BaseState initState)
    {
        curState = initState;
    }

    public void ChangeState(BaseState nextState)
    {
        // ���� State�� ��� �Լ� ����
        if (nextState == curState) { return; }

        // �̹� State�� ������ �� State�� ������ �Լ��� ȣ��
        curState?.OnStateExit();

        // �� State�� �ٲ�
        curState = nextState;
        curState.OnStateEnter();
    }

    /// <summary>
    /// ���� State �� �� ȣ��Ǵ� �Լ�
    /// </summary>
    public void UpdateState()
    {
        curState?.OnStateUpdate();
    }
}