using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : CharacterStat
{
    private int coin = 0;

    public int Coin { get { return coin; } }


    public void AddCoin(int coin) {  this.coin += coin; }

    public override void Death()
    {
        Debug.Log("game over");
    }

    public int UseCoin(int coin) 
    { 
        this.coin -= coin;

        if (this.coin < 0) 
            this.coin = 0;

        return coin; 
    }
}
