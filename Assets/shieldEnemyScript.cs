using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldEnemyScript : MonoBehaviour
{
    public GameObject shield;   
    public bool isShieldActive;
    public float shieldRechargeTimer = 10f;

    // Update is called once per frame
    void Update()
    {
        if(isShieldActive)
        {
            shield.SetActive(true);
        }
        if(!isShieldActive)
        {
            shield.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "BulletP" && isShieldActive)
        {
            StartCoroutine( ShieldRecharge());
        }
    }
    private IEnumerator ShieldRecharge()
    {
        isShieldActive = false;
        yield return new WaitForSeconds(shieldRechargeTimer);
        isShieldActive = true;
    }
}
