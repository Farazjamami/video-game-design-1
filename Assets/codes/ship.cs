using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship : MonoBehaviour
{
    public Rigidbody2D myrigidbody2D;
    public GameObject projectilePrefab;
    public GameObject projectileSpawnPoint;
    public GameObject explosionPrefab;

    public float acceleration;
    public float maxSpeed;
    public int maxArmour;
    public float fireRate;
    public float projectileSpeed;
    [HideInInspector] public float currentSpeed;
    [HideInInspector] public int currentArmour;
    protected bool canFire;

    private void Awake()
    {
        currentArmour = maxArmour;
        canFire = true;
    }

     private IEnumerator FireRateBuffer()
    {
        canFire = false;
        yield return new WaitForSeconds(fireRate);
        canFire = true; 
    }


    public void Thrust()
    {
        myrigidbody2D.AddForce(transform.up * acceleration);
        

    }

    private void FixedUpdate()
    {
        if (myrigidbody2D.velocity.magnitude > maxSpeed)
        {
            myrigidbody2D.velocity = myrigidbody2D.velocity.normalized * maxSpeed; 
        }
    }



    public void FireProjectile()
    {
        if (canFire)
        {
            GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.transform.position, transform.rotation);

            projectile.GetComponent<Projectile>().SetFiringShip(gameObject);

            projectile.GetComponent<Rigidbody2D>().AddForce(transform.up * projectileSpeed);

            StartCoroutine(FireRateBuffer());

            Destroy(projectile, 4);

        }

    }


    public void TakeDamage(int damageToTake)
    {
        currentArmour = currentArmour - damageToTake;
        if (currentArmour <= 0)
            Explode();
      
    }

    public void Explode()
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
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
















