using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D rb;
    private float inputH;
    [SerializeField] private float speedMovement;
    [SerializeField] private float jumpForce;
    private Animator animator;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        Move();
        Attack();
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

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("attack");
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetTrigger("jump");
        }
    }
}
