using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int maxHp = 100;
    public int curHp = 100;
    [SerializeField] HpBarState hpBarState;

    public void TakeDamage(int damage)
    {
        curHp -= damage;
        hpBarState.SetState(curHp, maxHp);

        if(curHp <= 0 )
        {
            Debug.Log("玩家死亡");
        }
    }

    public void Heal(int healAmount)
    {
        if(curHp <= 0) return;
        
        curHp += healAmount;
        if(curHp > maxHp) curHp = maxHp;
    }
}
