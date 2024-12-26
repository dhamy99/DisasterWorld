using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Slime : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform[] pointsPathfinding;
    [SerializeField] private float speed;
    private Transform pointToReach;
    private bool isAlive;
    [SerializeField] private float damage;
    void Start()
    {
        pointToReach = pointsPathfinding[1];
        isAlive = true;
        StartCoroutine(Move());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator Move()
    {
        while(isAlive)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointToReach.position, speed * Time.deltaTime);

            if (transform.position.x.Equals(pointsPathfinding[1].position.x))
            {
                pointToReach = pointsPathfinding[0];
                transform.SetPositionAndRotation(transform.position, new Quaternion(0, -180, 0, 1));
            }
            else if (transform.position.x.Equals(pointsPathfinding[0].position.x))
            {
                pointToReach = pointsPathfinding[1];
                transform.SetPositionAndRotation(transform.position, new Quaternion(0, 0, 0, 1));
            }
            yield return null;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.gameObject.CompareTag("PlayerDetection"))
        {

        }
       else if(other.gameObject.CompareTag("PlayerHitbox"))
        {
            other.gameObject.GetComponent<LifeEngine>().GetDamage(damage);
        }
    }
}
