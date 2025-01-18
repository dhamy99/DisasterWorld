using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeEngine : MonoBehaviour
{

    [SerializeField] private float lifes;
    [SerializeField] private GameObject healthBar;


    private void Start()
    {
        healthBar.GetComponent<Slider>().value = 1f;
    }

    public void GetDamage(float damage)
    {
        lifes-= damage;
        healthBar.GetComponent<Slider>().value = lifes * 0.01f;
        if(lifes <= 0 )
        {
           Destroy( this.gameObject );
        }
    }
}
