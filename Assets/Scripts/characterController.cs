using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class characterController : MonoBehaviour
{
    public float maxSpeed;
    public Rigidbody2D rb;
    public Camera cam;
    Vector2 mousePos;
    public float accel;
    public float decel;
    public float velocity;
    Vector2 direction;

    public int HP;

    void Start()
    {
        GameObject Camera = GameObject.FindGameObjectWithTag("MainCamera");
        cam = Camera.GetComponent<Camera>();
    }

    void Update()
    {
        //gets mouse position on screen
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);


        if (Input.GetKey(KeyCode.Space) && (rb.position.y <= mousePos.y-1 || rb.position.y >= mousePos.y+1 || rb.position.x <= mousePos.x-1 || rb.position.x >= mousePos.x+1)) //move forwards when space pressed
        {        
            direction = (mousePos - rb.position).normalized; //gets the angle towards the mouse 

            if (velocity <= maxSpeed)
            {
                velocity = Mathf.MoveTowards(velocity, maxSpeed, accel*Time.deltaTime);
            }

        }
        else{
            if (velocity > 0)
            {
                velocity = Mathf.MoveTowards(velocity, 0, decel*Time.deltaTime);

            }
        }
        if(HP<=0)
        {
            Die();
        }    
    }
    void MoveCharacter(Vector3 direction3)
    {
        if (velocity >= 0)
        {
            rb.MovePosition(transform.position + direction3 * velocity * Time.deltaTime);
        }
    }

    //this thing does the turning to mouse
    void FixedUpdate() 
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle; 
        MoveCharacter(direction);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == "BulletE")
        {
            bulletEnemyBasic bulletDamage = collision.GetComponent<bulletEnemyBasic>();

            HP -= bulletDamage.damage;
        }
        if(collision.tag == "StaticHurter")
        {
            HP -= 5;
        }
    }

    void Die()
    {
        Debug.Log("you died lmao");
    }
}
