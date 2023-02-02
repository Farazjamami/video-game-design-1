using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    int damageToGive = 1;
    GameObject firingShip;

    public void SetFiringShip(GameObject firer)
    {
        firingShip = firer;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ship otherObject = collision.GetComponent<ship>();

        if(otherObject && collision.gameObject != firingShip)
        {
            otherObject.TakeDamage(damageToGive);
            Destroy(gameObject);
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
