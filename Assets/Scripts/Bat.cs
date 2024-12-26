using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform[] pointsPathfinding;
    [SerializeField] private float speed;
    private bool isAlive;
    private int idPoint = 1;
    [SerializeField] private float damage;
    void Start()
    {
        isAlive = true;
        StartCoroutine(Move());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Move()
    {
        while (isAlive)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointsPathfinding[idPoint].position, speed * Time.deltaTime);

            if (transform.position.Equals(pointsPathfinding[idPoint].position))
            {
                if (idPoint == pointsPathfinding.Length - 1)
                {
                    idPoint = 0;
                }
                else
                {
                    idPoint++;
                }

                if (idPoint == 2)
                {
                    transform.SetPositionAndRotation(transform.position, new Quaternion(0, -180, 0, 1));
                }
                else if (idPoint == 5)
                {
                    transform.SetPositionAndRotation(transform.position, new Quaternion(0, 0, 0, 1));
                }
            }
            yield return null;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerDetection"))
        {

        }
        else if (other.gameObject.CompareTag("PlayerHitbox"))
        {
            other.gameObject.GetComponent<LifeEngine>().GetDamage(damage);
        }
    }
}
