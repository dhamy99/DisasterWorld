using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : MonoBehaviour
{
    private Animator anim;

    [SerializeField] private float damage;
    [SerializeField] private GameObject fireBall;
    [SerializeField] private Transform firBallSpawn;
    [SerializeField] private float shootDelay;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(AttackRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerDetection"))
        {
            
            if(other.gameObject.transform.position.x > this.transform.position.x)
            {
                transform.SetPositionAndRotation(transform.position, new Quaternion(0, -180, 0, 1));
            }
            else
            {
                transform.SetPositionAndRotation(transform.position, new Quaternion(0, 0, 0, 1));
            }
        }
        else if (other.gameObject.CompareTag("PlayerHitbox"))
        {
            other.gameObject.GetComponent<LifeEngine>().GetDamage(damage);
        }
    }

    IEnumerator AttackRoutine()
    {
        while (true)
        {
            anim.SetTrigger("atacar");
            yield return new WaitForSeconds(shootDelay);
        }
    }

    private void Shoot()
    {
        Instantiate(fireBall, firBallSpawn.position, transform.rotation);
    }
}
