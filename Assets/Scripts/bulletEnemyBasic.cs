using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bulletEnemyBasic : MonoBehaviour
{
    public int damage;
    void Start()
    {
        Destroy(this.gameObject, 1f);
    }


    private void OnTriggerEnter2D(Collider2D collision)  
    {
        if(collision.tag == "PlayerShip")
            {
            Destroy(this.gameObject);
            }
    }
}
