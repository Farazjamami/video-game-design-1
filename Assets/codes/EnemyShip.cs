using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : ship
{
    private Transform target;
    public bool canFireAtPlayer; 

    // Start is called before the first frame update
    void Start()
    {      
        target = FindObjectOfType<playership>().transform; 
    }

    void FlyTowardsPlayer()
    {
        Vector2 directionToFace = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);
        transform.up = directionToFace;
        //Thrust();

    }

    // Update is called once per frame
    void Update()
    {
        FlyTowardsPlayer();

        if (canFireAtPlayer)
        {
            FireProjectile();
        }
    }
}
