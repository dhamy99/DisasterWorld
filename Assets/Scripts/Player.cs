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

    [Header("Interaction elements")]
    [SerializeField] private Transform detectionPoint;
    [SerializeField] private float detectionRadio;
    [SerializeField] private LayerMask whatIsInteractable;

    [SerializeField] private GameObject respawnPoint;

    

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
        Interact();

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
            if(other.TryGetComponent(out Enemy enemy))
            {
                enemy.GetDamage(damage);
            }
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

    private void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            Collider2D collide = Physics2D.OverlapCircle(detectionPoint.position, detectionRadio, whatIsInteractable);

            if (collide != null)
            {
                
                if (collide.TryGetComponent(out IInteractuable interactuable))
                {
                    interactuable.Interact();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("DeathZone"))
        {
            GetComponent<LifeEngine>().GetDamage(10);
            transform.position = respawnPoint.transform.position;
        }
    }

}
