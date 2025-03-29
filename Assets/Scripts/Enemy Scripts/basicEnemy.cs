using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

//using System.Numerics;
using UnityEngine;

public class basicEnemy : MonoBehaviour
{    
    public Rigidbody2D rb;
    public Rigidbody2D playerRb;
    private Vector2 knownPlayerPos;    
    public float distanceToRPlyrPos;
    public float maxSpeed;
    public float accel;
    public float decel;
    public float vel;
    Vector2 lookDir;
    public int movementStyle; //the way the enemy moves, 0 = basic, 1 = floaty 
    public float visionDistance;
    public int keepDistanceRange = 5; //the distance the ship will stop accel near player, so it doesnt crash

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("PlayerShip");
        playerRb = player.GetComponent<Rigidbody2D>();
    }
    void  Update() 
    {
        distanceToRPlyrPos = Vector2.Distance(rb.position, playerRb.position); //get distance between player and this enemy
        if (vel <= 0) //if our speed is below zero, dont
        {
            vel = 0;
        }
        if(movementStyle == 0) //position based movement style
        {
        }
        if(movementStyle == 1) //force based movement style
        {
            rb.AddForce(this.gameObject.transform.up * vel * Time.deltaTime);
        }

        if (distanceToRPlyrPos <= visionDistance) // if player is in our FOV
        {
            knownPlayerPos = playerRb.position; //set the player position into known player position
            if (vel <= maxSpeed && (distanceToRPlyrPos >= keepDistanceRange || movementStyle == 1))  //if our speed is below max and we arnt too close
            {
                vel = Mathf.MoveTowards(vel, maxSpeed, accel*Time.deltaTime);
            }
            if (distanceToRPlyrPos <= keepDistanceRange && movementStyle != 1) //if close enought, stop
            {
                if(vel > 0)
                {
                    vel = Mathf.MoveTowards(vel, 0, decel*Time.deltaTime);
                }
            }            
        }
        else //if the player is out of our FOV, slow down
        {
            if(vel > 0)
            {
                vel = Mathf.MoveTowards(vel, 0, decel*Time.deltaTime);
            }
        }

    }

    void FixedUpdate() 
    {
        lookDir = knownPlayerPos - rb.position; //get the direction the player is in
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f; //get the angle the player is in
        rb.rotation = angle; //set this to look at the player
        MoveCharacter(lookDir);        

    }

    void MoveCharacter(Vector3 direction3)
    {
        if(vel >= 0)
        {
            rb.MovePosition(transform.position + direction3 * vel * Time.deltaTime);
        }
    }

}
