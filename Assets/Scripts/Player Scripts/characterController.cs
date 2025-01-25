using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class characterController : MonoBehaviour
{
    public float maxSpeed;
    float trueMaxSpeed;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public Camera cam;
    Vector2 mousePos;
    public float accel;
    public float decel;
    public float velocity;
    Vector2 direction;
    public float freeze;

    public int HP;

    void Start()
    {
        GameObject Camera = GameObject.FindGameObjectWithTag("MainCamera");
        cam = Camera.GetComponent<Camera>();
        trueMaxSpeed = maxSpeed;
    }

    void Update()
    {
        //gets mouse position on screen
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        maxSpeed = trueMaxSpeed - (trueMaxSpeed*(freeze/20));
        Color blueTint = new Color(255 - (255*(freeze/20)),255,255,255);
        spriteRenderer.color = blueTint;

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
            bulletEnemyBasic bulletInfo = collision.GetComponent<bulletEnemyBasic>();
            
            HP -= bulletInfo.damage;
            if(freeze < 10 && bulletInfo.freezeEff != 0)
            {
                freeze += bulletInfo.freezeEff;
                StartCoroutine(FreezeTimer());
            }
        }
        if(collision.tag == "StaticHurter")
        {
            HP -= 5;
        }
    }

    IEnumerator FreezeTimer()
    {
        yield return new WaitForSeconds(freeze);
        freeze -= 1;
    }
    void Die()
    {
        Debug.Log("you died lmao");
    }
}
