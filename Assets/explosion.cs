using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy" || collision.tag == "PlayerShip")
        {
            if(collision.tag == "Enemy")
            {
                basicEnemy targetScript = collision.GetComponent<basicEnemy>();
                targetScript.Damage(25);
            }
            else
            {
                characterController targetScript = collision.GetComponent<characterController>();
                targetScript.Damage(25);
            }
        }
    }

}
