using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicShooting : MonoBehaviour
{
    public Transform[] cannonChambers;
    public GameObject bulletPrefab;
    public int bulletsPerShot;
    public int bulletSpeed;
    public float fireRate;
    private float fireTimer;

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && fireTimer <= 0f)
        {
            Shoot(bulletsPerShot);
            fireTimer = fireRate;
        }else
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
        }
    }

}
