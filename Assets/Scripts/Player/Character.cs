using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IDamageable
{
    public int maxHp = 100;
    public int curHp = 100;
    [SerializeField] HpBarState hpBarState;

    void Start()
    {
        hpBarState.SetState(curHp, maxHp);
    }
    public void TakeDamage(int damage)
    {
        curHp -= damage;
        hpBarState.SetState(curHp, maxHp);

        if(curHp <= 0 )
        {
            GetComponent<CharacterGameOver>().GameOver();
        }
    }

    public void Heal(int healAmount)
    {
        if(curHp <= 0) return;
        
        curHp += healAmount;
        if(curHp > maxHp) curHp = maxHp;
        hpBarState.SetState(curHp, maxHp);
    }
}
