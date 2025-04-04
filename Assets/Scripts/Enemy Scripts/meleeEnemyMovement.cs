using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Collections;
using UnityEngine;

public class meleeEnemyMovement : MonoBehaviour
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
    public bool hunting = false; 
    public float idleStrgh;
    public float visionDistance;

    void Start()
    { //load up the player
        GameObject player = GameObject.FindGameObjectWithTag("PlayerShip");
        playerRb = player.GetComponent<Rigidbody2D>();
        //StartCoroutine(randomIdleDirCoroutine()); //this just didnt work at all
    }
    void  Update() {
        distanceToRPlyrPos = Vector2.Distance(rb.position, playerRb.position); //figure out the distance to player
        if(distanceToRPlyrPos > 7 && distanceToRPlyrPos <= visionDistance)
        {    
            lookDir = knownPlayerPos - rb.position;
        }
        if (vel <= 0)
        {
            vel = 0;
        }
            rb.position += lookDir * vel * Time.deltaTime;

        if (distanceToRPlyrPos <= visionDistance) //if player is in range
        {
            hunting = true;
            knownPlayerPos = playerRb.position;
            if (vel <= maxSpeed ) //if not max speed
            {
                vel += accel*Time.deltaTime;
            }
        }
        else
        {
            hunting = false;
            if(vel >= 0)
            {
                vel -= decel*Time.deltaTime;
            }
        }
        
    }

    void FixedUpdate() 
    {
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle; 
    }



    // IEnumerator randomIdleDirCoroutine() //idle movement
    // {
    //     while(true)
    //     {
    //         yield return new WaitForSeconds(4);
    //         if (!hunting) //if were not hunting(havent seen the player yet), this thing is mostly working, i just have no idea why it can still go out of bounds but its unlikley. add a fix later
    //         {
    //             Vector2 RandVec; //making a random vector modifier
    //             for (RandVec = new Vector2(Random.Range(-180f,180f),Random.Range(-180f,180f)); true; RandVec = new Vector2(Random.Range(-180f,180f),Random.Range(-180f,180f)))
    //             {
    //                 float dist = Vector2.Distance(new Vector2(0,0), new Vector2(RandVec.x, RandVec.y)); //saving the distance between our combined vectors
    //                 if(dist < 150) //if the new distance ends up in bounds than break
    //                 {
    //                     break;
    //                 }
    //             }
    //             lookDir = new Vector2(RandVec.x, RandVec.y); //turn to the inbout position
    //             vel = idleStrgh; //short burst of velocity
    //         }
    //     }
    // }

}
