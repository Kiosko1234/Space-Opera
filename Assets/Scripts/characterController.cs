using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public Camera cam;
    Vector2 mousePos;
    public float accel;
    public float decel;
    public float velocity;


    void Update()
    {
        //gets mouse position on screen
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - rb.position).normalized; //gets the angle towards the mouse 

        if (Input.GetKey(KeyCode.Space)) //move forwards when space pressed
        {
            rb.position += direction * speed * Time.fixedDeltaTime;
        }
    }

    //this thing does the turning to mouse
    void FixedUpdate() 
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle; 
    }
}
