using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playership : ship
{
    





   // Start is called before the first frame update
    void Start()
    {
        currentArmour = maxArmour;
    }

    public void HandleInput()
    {
        if (Input.GetMouseButton(1))
            Thrust();

        if (Input.GetMouseButtonDown(0))
            FireProjectile(); 
    }

    public void FollowMouse()
    {

        //take the coordinates off the mouse click and convert into world coordinates.
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));

        Vector2 directionToFace = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = directionToFace; 
    }





    // Update is called once per frame
    void Update()
    {
        FollowMouse(); 
        HandleInput(); 
    }



}

