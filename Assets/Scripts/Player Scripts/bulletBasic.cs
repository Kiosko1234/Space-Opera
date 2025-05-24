using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bulletBasic : MonoBehaviour
{
    public int damage;
    void Start()
    {
        Destroy(this.gameObject, 1f);
    }


    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.tag == "Enemy" || collision.tag == "DamagableObject")
            {
            healthManager target = collision.GetComponent<healthManager>();
            target.Damage(damage);
            Destroy(this.gameObject);
            }
        if(this.gameObject.tag == "BulletP" && collision.tag == "BulletE")
            Destroy(this.gameObject);
        if(this.gameObject.tag == "BulletE" && collision.tag == "BulletP")
            Destroy(this.gameObject);
        if(collision.tag == "Planet")
            Destroy(this.gameObject);


    }
}
