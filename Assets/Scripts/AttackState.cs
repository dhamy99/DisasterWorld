using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State<EnemyController>
{

    [SerializeField] private float attackDistance;
    [SerializeField] private float attackDelay;

    private Player player;

    private float timer;
    public override void OnEnterState(EnemyController controller)
    {
        base.OnEnterState(controller);
    }
    public override void OnUpdateState()
    {
        timer += Time.deltaTime;
        if (timer > attackDelay)
        {
            GetComponent<Enemy>().Attack();
        }
    }
    public override void OnExitState()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player player))
        {
            this.player = player;
        }
    }

}
