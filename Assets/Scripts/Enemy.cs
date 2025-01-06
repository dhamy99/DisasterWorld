using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{

    [SerializeField] private float life;

    protected float Life { get => life; set => life = value; }

    public abstract void Attack();

    public void GetDamage(float damage)
    {
        life -= damage;

        if (life <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
