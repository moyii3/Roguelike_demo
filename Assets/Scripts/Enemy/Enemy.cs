using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public Transform target;
    public float speed = 5f;
    public float explosionRadius = 5f;
    public int explosionDamageAmount = 1;
    public bool explosion = false;
    public bool isDead = false;
    public LayerMask enemyMask;

    [SerializeField] int hp = 3;
    [SerializeField] int damage = 1;
    [SerializeField] int experienceReward = 400;


    Character playerCharacter;
    private Rigidbody rb;
    private GameObject attackGameObject;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //target = GameObject.FindGameObjectWithTag("Player").transform;
        target = GameManager.instance.playerTransfrom;
        attackGameObject = target.gameObject;
    }

    private void FixedUpdate()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        direction.y = 0;
        transform.LookAt(transform.position + direction);
        rb.velocity = direction * speed;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject == attackGameObject)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if(playerCharacter == null)
        {
            playerCharacter = attackGameObject.GetComponent<Character>();
        }

        playerCharacter.TakeDamage(damage);
    }

    public void TakeDamage(int damage)
    {
        if(isDead) return;

        hp -= damage;

        if(hp < 1)
        {
            isDead = true;

            attackGameObject.GetComponent<Level>().AddExperience(experienceReward);
            GetComponent<DropOnDestroy>().CheckDrop();
            if(explosion != false)
            {
                DieToExplode();
            }
            Destroy(gameObject);
        }
    }

    public void DieToExplode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, enemyMask);
        ExplosionDamage(colliders);
    }

    void ExplosionDamage(Collider[] colliders)
    {
        foreach(var col in colliders)
        {
            if (col.gameObject != transform.gameObject)
            {
                col.transform.GetComponent<IDamageable>().TakeDamage(explosionDamageAmount);
            }
        }
    }
}
