using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : TopDownController
{
    public float attackRange;


    private Player player;

    private Coroutine attackCoroutine;

    public int reward;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    private void Start()
    {
        fsm = new FSM(new AttackState(this));
    }

    private void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < attackRange) StartAttack();
        else StopAttack();
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
        CharacterStat stat = player.Stat;

        while (true)
        {
            stat.ChangeHealth(-stat.attack);

            // 일단 하드 코딩..
            yield return new WaitForSeconds(3f);
        }
    }

    private void OnDestroy()
    {
        (player.Stat as PlayerStat).AddCoin(reward);
    }
}
