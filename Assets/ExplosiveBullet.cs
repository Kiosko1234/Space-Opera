using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBullet : MonoBehaviour
{
    public float explosionCounter;
    public float explosionTimer;
    public GameObject explosionPrefab;
    bool exploded = false;

    void Update()
    {
        explosionCounter += Time.deltaTime * 1;
        if (explosionCounter >= explosionTimer)
        {
            Explosion();
        }
    }

    void Explosion()
    {
        GameObject explosion = Instantiate(explosionPrefab, new Vector3(this.gameObject.transform.position.x,this.gameObject.transform.position.y,0), new Quaternion(0, 0, 0, 0));
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)  
    {
        if (collision.tag == "PlayerShip" || collision.tag == "BulletP")
        {
            Explosion();
        }
    }
}
