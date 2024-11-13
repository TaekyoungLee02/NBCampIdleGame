using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PlayerController : TopDownController
{
    public float chaseRange;
    public float attackRange;
    private State curState;
    private Enemy currentEnemy;

    private Coroutine attackCoroutine;

    private CharacterStat stat;

    private void Awake()
    {
        stat = GetComponent<CharacterStat>();
    }

    private void Start()
    {
        curState = State.Idle;
        fsm = new FSM(new IdleState(this));
    }

    private void Update()
    {
        switch (curState)
        {
            case State.Idle:
                if (CanSeePlayer())
                {
                    if (CanAttackPlayer())
                        ChangeState(State.Attack);
                    else
                        ChangeState(State.Move);
                }
                break;
            case State.Move:
                if (CanSeePlayer())
                {
                    if (CanAttackPlayer())
                    {
                        ChangeState(State.Attack);
                    }
                }
                else
                {
                    ChangeState(State.Idle);
                }
                break;
            case State.Attack:
                if (CanSeePlayer())
                {
                    if (!CanAttackPlayer())
                    {
                        ChangeState(State.Move);
                    }
                }
                else
                {
                    ChangeState(State.Idle);
                }
                break;
        }

        fsm.UpdateState();

    }

    private void ChangeState(State nextState)
    {
        curState = nextState;
        switch (curState)
        {
            case State.Idle:
                fsm.ChangeState(new IdleState(this));
                break;
            case State.Move:
                fsm.ChangeState(new MoveState(this));
                break;
            case State.Attack:
                fsm.ChangeState(new AttackState(this));
                break;
        }
    }

    private bool CanSeePlayer()
    {
        var enemies = Physics.OverlapSphere(transform.position, chaseRange, 1 << LayerMask.NameToLayer("Enemy"));

        if (enemies.Length == 0) return false;

        currentEnemy = enemies[0].GetComponent<Enemy>();

        return true;
    }

    private bool CanAttackPlayer()
    {
        if (currentEnemy == null) return false;

        if (attackRange > Vector3.Distance(currentEnemy.transform.position, transform.position)) return true;
        else return false;
    }

    public void ChaseEnemy()
    {
        if (currentEnemy == null) return;
        base.SetDestination((currentEnemy.transform.position - transform.position).normalized);
    }

    public override void StartAttack()
    {
        if (attackCoroutine != null) StopCoroutine(attackCoroutine);
        attackCoroutine = StartCoroutine(AttackCoroutine());
    }

    public override void StopAttack()
    {
        if (attackCoroutine != null) StopCoroutine(attackCoroutine);
        attackCoroutine = null;
    }

    private IEnumerator AttackCoroutine()
    {
        CharacterStat stat = currentEnemy.Stat;

        while (true)
        {
            stat.ChangeHealth(-stat.attack);

            Debug.Log(curState);


            // 일단 하드 코딩..
            yield return new WaitForSeconds(3f);
        }
    }
}
