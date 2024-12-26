using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeEngine : MonoBehaviour
{

    [SerializeField] private float lifes;



    public void GetDamage(float damage)
    {
        lifes-= damage;

        if(lifes <= 0 )
        {
           Destroy( this.gameObject );
        }
    }
}
