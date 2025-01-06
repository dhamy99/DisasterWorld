using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private PatrolState patrolState;
    private AttackState attackState;
    private ChaseState chaseState;

    private State<EnemyController> currentState;

    public PatrolState PatrolState { get => patrolState;}
    public AttackState AttackState { get => attackState;}
    public ChaseState ChaseState { get => chaseState;}
    public State<EnemyController> CurrentState { get => currentState; set => currentState = value; }

    // Start is called before the first frame update
    void Start()
    {
        patrolState = GetComponent<PatrolState>();
        attackState = GetComponent<AttackState>();
        chaseState = GetComponent<ChaseState>();

        ChangeState(patrolState);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentState)
        {
            currentState.OnUpdateState();
        }
    }

    public void ChangeState(State<EnemyController> state)
    {
        if(currentState)
        {
            currentState.OnExitState();
        }

        currentState = state;
        currentState.OnEnterState(this);
    }
}
