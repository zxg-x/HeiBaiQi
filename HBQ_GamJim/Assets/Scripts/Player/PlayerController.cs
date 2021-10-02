using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageable
{
    private Rigidbody2D rb;

    public float speed;
    public float jumpForce;

    [Header("Player State")]
    public float health;
    public bool isDead;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask groundLayer;

    [Header("States Check")]
    public bool isGround;
    public bool canJump;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckInput();
    }
    // Update is called once per frame
    public void FixedUpdate()
    {
        PhysicsCheck();
        Movement();
        Jump();
    }
    void CheckInput()
    {
        if(Input.GetButtonDown("Jump")&&isGround)
        {
            canJump = true;
        }
    }
    void Movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        if(horizontalInput!=0)
        {
            transform.localScale = new Vector3(-horizontalInput, 1, 1);
        }
    }

    void Jump()
    {
        if(canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            rb.gravityScale = 4;
            canJump = false;
        }
    }

    void PhysicsCheck()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position,checkRadius,groundLayer);
        if(isGround)
        {
            rb.gravityScale = 1;
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }

    public void GetHit(float damage)
    {
        health = 0;
    }
}
