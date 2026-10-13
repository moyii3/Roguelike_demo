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
    public Vector3 targetPosition;

    public float timeToAttack = 2f;
    private float timer = 2f;
    public bool triAttack = false;
    private Character playerCharacter;
    PlayerController playerController;
    [SerializeField] Vector3 whipAttackHalfSize = new Vector3(2f, 2f, 2f);
    [SerializeField] int whipDamage = 1;

    private void Awake()
    {
        playerController = GetComponentInParent<PlayerController>();
        playerCharacter = GameManager.instance.playerTransfrom.GetComponent<Character>();
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0f)
        {
            Attack();
            if (triAttack)
            {   
                Invoke("Attack", 0.25f);
                Invoke("Attack", 0.5f);
            }
        }
    }

    int FINAL_DAMAGE
    {
        
        get
        {
            return whipDamage + playerCharacter.strength;   
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


        /*Vector3 pos = leftAttack.transform.position;
        float y = pos.y;
        
        targetPosition = playerController.lastDirection + pos;
        targetPosition.y = y;

        leftAttack.transform.LookAt(targetPosition * 100);
        leftAttack.Play();

        Collider[] colliders = Physics.OverlapBox(transform.position + 2 * playerController.lastDirection, whipAttackHalfSize);
        ApplyDamage(colliders);*/

        timer = timeToAttack;

    }

    private void ApplyDamage(Collider[] colliders)
    {
        foreach(Collider col in colliders)
        {
            IDamageable damageable = col.GetComponent<IDamageable>();
            if(damageable != null && col.tag != "Player")
            {
                damageable.TakeDamage(FINAL_DAMAGE);
            }
        }
    }
}
