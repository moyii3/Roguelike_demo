using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipWeapon : MonoBehaviour
{
    public ParticleSystem leftAttack;
    public ParticleSystem rightAttack;
    public ParticleSystem upAttack;
    public ParticleSystem downAttack;

    private float timeToAttack = 2f;
    private float timer = 2f;
    PlayerController playerController;
    [SerializeField] Vector3 whipAttackHalfSize = new Vector3(2f, 2f, 2f);
    [SerializeField] int whipDamage = 1;

    private void Awake()
    {
        playerController = GetComponentInParent<PlayerController>();
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0f)
        {
            Attack();
        }
    }

    private void Attack()
    {   
        if(playerController.lastHorizontal > 0)
        {
            rightAttack.Play();
            Collider[] colliders = Physics.OverlapBox(transform.position - 2 * Vector3.left, whipAttackHalfSize); //攻击触发范围
            ApplyDamage(colliders);
        }
        else
        {
            leftAttack.Play();
            Collider[] colliders = Physics.OverlapBox(transform.position + 2 * Vector3.left, whipAttackHalfSize); //攻击触发范围
            ApplyDamage(colliders);
        }
        timer = timeToAttack;
    }

    private void ApplyDamage(Collider[] colliders)
    {
        foreach(Collider col in colliders)
        {
            if(col.tag == "Enemy")
            {
                col.GetComponent<Enemy>().TakeDamage(whipDamage);
            }
        }
    }
}
