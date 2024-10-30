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
    public int hp;
    public int movementStyle; //the way the enemy moves, 0 = basic, 1 = floaty 

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("PlayerShip");
        playerRb = player.GetComponent<Rigidbody2D>();
    }
    void  Update() {
        distanceToRPlyrPos = Vector2.Distance(rb.position, playerRb.position);
        if (vel <= 0)
        {
            vel = 0;
        }
        if(movementStyle == 0)
        {
            rb.position += lookDir * vel * Time.deltaTime;
        }
        if(movementStyle == 1)
        {
            rb.AddForce(this.gameObject.transform.up * vel * Time.deltaTime);
        }

        if (distanceToRPlyrPos <= 10)
        {
            knownPlayerPos = playerRb.position;
            if (vel <= maxSpeed && (distanceToRPlyrPos >= 5 || movementStyle == 1)) 
            {
                vel += accel*Time.deltaTime;
            }
            if (distanceToRPlyrPos <= 5 && movementStyle != 1)
            {
                if(vel >= 0)
                {
                    vel -= decel* Time.deltaTime;
                }
            }            
        }
        else
        {
            if(vel >= 0)
            {
                vel -= decel*Time.deltaTime;
            }
        }
        if (hp <= 0)
            Die();

    }

    void FixedUpdate() 
    {
        lookDir = knownPlayerPos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle; 
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        bulletBasic bulletDamage = collision.GetComponent<bulletBasic>();
        if (collision.tag == "BulletP")
        {
            hp -= bulletDamage.damage;
        }
    }

    void Die()
    {
        levelManager.Complesion++;
        Destroy(this.gameObject);
    }

}
