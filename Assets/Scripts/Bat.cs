using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Enemy
{
    // Start is called before the first frame update
    [SerializeField] private float damage;

    private EnemyController controller;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

  

    

    public override void Attack()
    {
        Debug.Log("asdfsadfsdf");
    }
}
