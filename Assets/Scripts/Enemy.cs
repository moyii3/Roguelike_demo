using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;

    [SerializeField] int hp = 3;

    private Rigidbody rb;
    private GameObject attackGameObject;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
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
        Debug.Log("attacking");
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if(hp < 1)
        {
            Destroy(gameObject);
        }
    }
}
