using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D rb;
    private float inputH;
    [Header("Movement System")]
    [SerializeField] private float speedMovement;
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform playerFoots;
    [SerializeField] private LayerMask beJumpable;
    [SerializeField] private float radiusJump;
    private Animator animator;

    [Header("Combat Engine")]
    [SerializeField] private Transform pointAttack;
    [SerializeField] private float radiusAttack;
    [SerializeField] private LayerMask beDamaged;
    [SerializeField] private float damage;

    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        Move();
        BeginAttack();
        Jump();
    
    }

    private void Move()
    {
        inputH = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(inputH * speedMovement, rb.velocity.y);

        if (inputH > 0)
        {
            animator.SetBool("isMoving", true);
            transform.SetPositionAndRotation(transform.position, new Quaternion(0,0,0,1));
        }
        else if(inputH < 0)
        {
            transform.SetPositionAndRotation(transform.position, new Quaternion(0, -180, 0, 1));
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
            
        }

    }

    private void BeginAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("attack");
        }
    }

    private void Attack()
    {
        Collider2D[] others = Physics2D.OverlapCircleAll(pointAttack.position, radiusAttack, beDamaged);

        foreach(Collider2D other in others)
        {
            other.gameObject.GetComponent<LifeEngine>().GetDamage(damage);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && BeOnGround())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetTrigger("jump");
        }
    }

    private bool BeOnGround()
    {
        return Physics2D.Raycast(playerFoots.position, Vector3.down, radiusJump, beJumpable);
    }
}
