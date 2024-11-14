using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : CharacterStat
{

    public override void Death()
    {
        Destroy(gameObject);
    }
}
