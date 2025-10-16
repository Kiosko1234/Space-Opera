using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suicideEnemy : MonoBehaviour
{
    int phase = 0;
    public GameObject[] bullet; 
    public float maxFireDistance = 5f;
    public float fireRate;
    float fireTimer;

    public Animator anim;

    float DistanceToTarget;
    private Rigidbody2D rb;
    private Rigidbody2D playerRb;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("PlayerShip");
        playerRb = player.GetComponent<Rigidbody2D>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        DistanceToTarget = Vector2.Distance(rb.position, playerRb.position); //get distance between player and this enemy
        if(fireTimer <= 0 && DistanceToTarget <= maxFireDistance)
        {
            if (phase == 0 && anim.GetInteger("animPhase") == phase)
            {
                StartCoroutine(FirstShotCoroutine());
            }if (phase == 1 && anim.GetInteger("animPhase") == phase)
            {
                StartCoroutine(SecondShotCoroutine());
            }if (phase == 2 && anim.GetInteger("animPhase") == phase)
            {
                StartCoroutine(ThirdShotCoroutine());
            }    
            fireTimer = fireRate;
            
        }
        else
        {
            fireTimer -= Time.deltaTime;
        }
    }

    IEnumerator FirstShotCoroutine()
    {
        anim.SetInteger("animPhase", 1);
        yield return new WaitForSeconds(3);
        phase = 1;
    }
    IEnumerator SecondShotCoroutine()
    {
        anim.SetInteger("animPhase", 2);
        yield return new WaitForSeconds(3);
        phase = 2;
    }
    IEnumerator ThirdShotCoroutine()
    {
        anim.SetInteger("animPhase", 3);
        yield return new WaitForSeconds(3);
        phase = 3;
    }
}
