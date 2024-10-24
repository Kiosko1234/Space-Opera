using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class basicEnemy : MonoBehaviour
{    
    public Rigidbody2D rb;
    public Rigidbody2D playerRb;
    private UnityEngine.Vector2 knownPlayerPos;    
    private float distanceToRPlyrPos;
    private bool hunting;
    public float maxSpeed;
    public float accel;
    public float decel;
    public float vel;

    void  Update() {
        distanceToRPlyrPos = UnityEngine.Vector2.Distance(rb.position, playerRb.position);
        rb.AddForce(this.gameObject.transform.up * vel * Time.fixedDeltaTime);

        if (distanceToRPlyrPos <= 10)
        {
            hunting = true;
            knownPlayerPos = playerRb.position;
        }
        else
        {
            hunting = false;
        }

        if (hunting)
        {
            
        }
    }

    void FixedUpdate() 
    {
        UnityEngine.Vector2 lookDir = knownPlayerPos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle; 
    }


}
