using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bulletEnemyBasic : MonoBehaviour
{
    public int damage;
    public int freezeEff;
    public int poison;
    void Start()
    {
        Destroy(this.gameObject, 1f);
    }


    private void OnTriggerEnter2D(Collider2D collision)  
    {
        if(collision.tag == "PlayerShip")
        {
            healthManager target = collision.GetComponent<healthManager>();
            target.Damage(damage, "bullet");
            Destroy(this.gameObject);
        }
    }


}
