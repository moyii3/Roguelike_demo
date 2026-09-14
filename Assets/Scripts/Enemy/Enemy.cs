using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public Transform target;
    public float speed = 5f;

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
        hp -= damage;

        if(hp < 1)
        {
            attackGameObject.GetComponent<Level>().AddExperience(experienceReward);
            GetComponent<DropOnDestroy>().CheckDrop();
            Destroy(gameObject);
        }
    }
}
