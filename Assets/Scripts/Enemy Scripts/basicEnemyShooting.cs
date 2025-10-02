using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class basicEnemyShooting : MonoBehaviour
{
    public Transform[] cannonChambers;
    public GameObject bulletPrefab;
    public int bulletsPerShot;
    public int bulletSpeed;
    public float fireRate = 3;
    public float fireTimer;
    public float maxFireDistance = 5f;
    public float dropoff = 0;

    float DistanceToTarget;
    private Rigidbody2D rb;
    private Rigidbody2D playerRb;
    // public float raycastOffset;
    public GameObject raycastOrigin; 
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("PlayerShip");
        playerRb = player.GetComponent<Rigidbody2D>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        // Vector2 customOffset = transform.up * 0.5f + transform.right * 0.2f;
        //Vector2 raycastOrigin = Quaternion.AngleAxis(rb.gameObject.transform.rotation.eulerAngles.z, rb.position) * new Vector2(rb.position.x, rb.position.y + raycastOffset); //broken
        // Vector2 origin = (Vector2)transform.position * customOffset;
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin.transform.position, transform.up, maxFireDistance);
//         Debug.DrawRay(raycastOrigin.transform.position, transform.up, Color.yellow, 0.05f);

           // if (hit.collider != null && hit.collider.gameObject != this.gameObject)
            //{
                    //Debug.Log("ye");
            //}
        if(fireTimer <= 0 && hit.collider != null)
        {
            if(hit.collider.gameObject.tag == "PlayerShip")
            {
                Shoot(bulletsPerShot);
                fireTimer = fireRate;
            }
        }
        else
        {
            Debug.Log("no");
            fireTimer -= Time.deltaTime;
        }
        // if(hit && hit.transform.CompareTag("PlayerShip"))
        // {
        // }
        // DistanceToTarget = Vector2.Distance(rb.position, playerRb.position); //get distance between player and this enemy
        // if (DistanceToTarget <= maxFireDistance && fireTimer <= 0f)
        // {
        //     Shoot(bulletsPerShot);
        //     fireTimer = fireRate;
        // }else
        // {
        //     fireTimer -= Time.deltaTime;
        // }
    }    
    
    void Shoot(int count)
    {
       for (int k=0; k < count; k++)
        {
            GameObject bullet = Instantiate(bulletPrefab, cannonChambers[k].position, cannonChambers[k].rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(cannonChambers[k].up * bulletSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);
            rb.drag = dropoff;
        }
    }

}
