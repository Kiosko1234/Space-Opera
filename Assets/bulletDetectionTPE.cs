using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletDetectionTPE : MonoBehaviour
{
    teleportEnemy te;
    void Start()
    {
        te = this.gameObject.GetComponentInParent<teleportEnemy>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BulletP")
        {
            te.Leport();
            //Destroy(this.gameObject);
        }
    }
}
