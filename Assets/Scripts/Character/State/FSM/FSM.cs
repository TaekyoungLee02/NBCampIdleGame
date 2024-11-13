using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM
{
    private BaseState curState;

    public BaseState CurState { get { return curState; } }

    public FSM(BaseState initState)
    {
        curState = initState;

        ChangeState(curState);
    }

    public void ChangeState(BaseState nextState)
    {
        // 현재 State일 경우 함수 종료
        if (nextState == curState) { return; }

        // 이미 State가 있으면 그 State를 끝내는 함수를 호출
        curState?.OnStateExit();

        // 새 State로 바뀜
        curState = nextState;
        curState.OnStateEnter();
    }

    /// <summary>
    /// 현재 State 일 때 호출되는 함수
    /// </summary>
    public void UpdateState()
    {
        curState?.OnStateUpdate();
    }
}
