using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
            healthManager targetScript = collision.GetComponent<healthManager>();
            if(targetScript != null)
            {
                targetScript.Damage(25);
            }
            else
            {
                Debug.LogError("somehow you forgor to add a healthManager to an object that should have it, go fix it you failure");
            }
        }
    }

}
