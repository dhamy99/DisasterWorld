using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State<EnemyController>
{
    [SerializeField] private Transform pathfinding;
    [SerializeField] private float speed;
    private int idPoint = 0;

    private List<Vector3> listPositions = new List<Vector3>();

    private Vector3 currentDestination = new Vector3();
    public override void OnEnterState(EnemyController enemyController)
    {
        base.OnEnterState(enemyController);
        
        foreach (Transform point in pathfinding)
        {
            listPositions.Add(point.position);
            
        }

        currentDestination = listPositions[idPoint];

    }
    public override void OnUpdateState()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentDestination, speed * Time.deltaTime);
        if(transform.position == currentDestination)
        {
            CalculateNewDestination();
        }
    }

    public override void OnExitState()
    {
        listPositions.Clear();
        idPoint = 0;
    }

    public void CalculateNewDestination()
    {
        idPoint++;
        if(idPoint > listPositions.Count - 1)
        {
            idPoint = 0;
        }
        currentDestination = listPositions[idPoint];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerDetection"))
        {
            controller.ChangeState(controller.ChaseState);
        }
    }


}
