using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 5f;

    
    [HideInInspector]
    public Vector3 moveDirection;
    [HideInInspector]
    public float lastHorizontal;
    [HideInInspector]
    public float lastVertical;
    void Awake()
    {
        
    }


    void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void GetInput()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); // A/D
        float vertical = Input.GetAxisRaw("Vertical"); // W/S

        if(horizontal != 0)
        {
            lastHorizontal = horizontal;
        }
        if(vertical != 0)
        {
            lastVertical = vertical;
        }

        moveDirection = (transform.right * horizontal + transform.forward * vertical);

        moveDirection.Normalize(); // 归一化，防止斜向速度更快
    }

    private void Move()
    {
        rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z) * moveSpeed;
    }
}
