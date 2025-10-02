using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeBurstMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Rigidbody2D playerRb;
    private Vector2 knownPlayerPos;
    public float distanceToRPlyrPos;
    public float maxSpeed;
    public float vel;
    Vector2 lookDir;
    public bool hunting = false;
    public float restingDelay;
    public float huntingDelay;
    public float visionDistance;


    void Start()
    { //load up the player
        GameObject player = GameObject.FindGameObjectWithTag("PlayerShip");
        playerRb = player.GetComponent<Rigidbody2D>();
        StartCoroutine(restingCoroutine());
    }
    void Update()
    {
        distanceToRPlyrPos = Vector2.Distance(rb.position, playerRb.position); //figure out the distance to player
        // if (hunting && distanceToRPlyrPos <= visionDistance)
        // {
        //     lookDir = knownPlayerPos - rb.position;
        // }
        if (vel <= 0)
        {
            vel = 0;
        }
        //rb.position += lookDir * vel * Time.deltaTime; //this moves the ship
        transform.position += transform.up * vel * Time.deltaTime;
        knownPlayerPos = playerRb.position;

        if (distanceToRPlyrPos <= visionDistance && hunting) //if player is in range
        {
            vel = maxSpeed; //speeeeed
        }
        else
        {
            vel = 0; //speednt
        }

    }

    void FixedUpdate()
    {
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    IEnumerator restingCoroutine()
    {
        hunting = false;
        yield return new WaitForSeconds(restingDelay);
        StartCoroutine(huntingCoroutine());
    }

    IEnumerator huntingCoroutine()
    {
        hunting = true;
        lookDir = knownPlayerPos - rb.position;
        yield return new WaitForSeconds(huntingDelay);
        StartCoroutine(restingCoroutine());
    }
}
