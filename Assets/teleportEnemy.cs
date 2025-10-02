using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportEnemy : MonoBehaviour
{
    public bool teleported = false;
    basicEnemy be;
    Rigidbody2D rb;
    Rigidbody2D playerRb;
    Transform trans;
    private Vector2 vectorToPlayer;

    public Object tParticles;

    // Start is called before the first frame update
    void Start()
    {
        be = this.gameObject.GetComponent<basicEnemy>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        trans = this.gameObject.GetComponent<Transform>();
        playerRb = GameObject.FindGameObjectWithTag("PlayerShip").GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!teleported)
        {
            vectorToPlayer = playerRb.position - rb.position;
        }
    }

    public void Leport()
    {
        trans.position += new Vector3(vectorToPlayer.x * 2,vectorToPlayer.y * 2, 0);
    }

}
