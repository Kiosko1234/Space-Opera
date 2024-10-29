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

        rb.position += direction * velocity * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && (rb.position.y <= mousePos.y-1 || rb.position.y >= mousePos.y+1 || rb.position.x <= mousePos.x-1 || rb.position.x >= mousePos.x+1)) //move forwards when space pressed
        {        
            direction = (mousePos - rb.position).normalized; //gets the angle towards the mouse 

            if (velocity <= maxSpeed)
                velocity += accel* Time.deltaTime;
            else
                velocity = maxSpeed;
        }
        else{
            if (velocity >= 0)
            {
                velocity -= decel* Time.deltaTime;
                if (velocity <= 0)
                    velocity = 0;
            }
        }
        if(HP<=0)
        {
            Die();
        }    
    }

    //this thing does the turning to mouse
    void FixedUpdate() 
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle; 
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == "BulletE")
        {
            bulletEnemyBasic bulletDamage = collision.GetComponent<bulletEnemyBasic>();

            HP -= bulletDamage.damage;
        }
    }

    void Die()
    {
        Debug.Log("you died lmao");
    }
}
