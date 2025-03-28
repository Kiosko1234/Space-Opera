using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class roombaExplosion : MonoBehaviour
{
    public float explosionCounter;
    public int explosionTimer;
    SpriteRenderer thisSprite;
    basicEnemy movementScript;
    bool activeDetonation;
    public GameObject explosionParticlesPrefab;
    public GameObject explosionHitbox;
    bool exploded = false; 

    // Start is called before the first frame update
    void Start()
    {
        movementScript = this.gameObject.GetComponent<basicEnemy>();
        Debug.Log(movementScript + " loaded");
        thisSprite = this.gameObject.GetComponent<SpriteRenderer>();
        Debug.Log(thisSprite + " loaded");
        activeDetonation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(movementScript.distanceToRPlyrPos <= movementScript.keepDistanceRange)
        {
            activeDetonation = true;
        }
        if(activeDetonation)
        {
            explosionCounter += Time.deltaTime * 1;
            thisSprite.color = new Color(1,math.sin(explosionCounter*6.3f),math.sin(explosionCounter*6.3f),1);
        }
        if(explosionCounter >= explosionTimer && !exploded)
        {
            explosionHitbox.SetActive(true);
            GameObject explosionParticles = Instantiate(explosionParticlesPrefab, this.gameObject.transform.position, new Quaternion(0,0,0,0));
            exploded = true;
        }
        if(explosionCounter >= explosionTimer + Time.deltaTime * 5)
        {
            Debug.Log("delete");
            Destroy(this.gameObject);
        }
    }
}
