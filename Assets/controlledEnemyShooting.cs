using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlledEnemyShooting : MonoBehaviour
{
    public Transform[] cannonChambers;
    public GameObject bulletPrefab;
    public int bulletsPerShot;
    public int bulletSpeed;
    public float fireRate = 3;
    public float fireTimer;
    public float maxFireDistance = 5f;
    public float dropoff = 0;

    private Rigidbody2D rb;
    private Rigidbody2D playerRb;
    public bool canShoot = false;
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("PlayerShip");
        playerRb = player.GetComponent<Rigidbody2D>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        if(fireTimer <= 0 && canShoot)
        {
            Shoot(bulletsPerShot);
            fireTimer = fireRate;
        }
        else
        {
            fireTimer -= Time.deltaTime;
        }
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
