using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class deathFog : MonoBehaviour
{
    public Image fog;
    public TextMeshProUGUI fogText;
    public float levelSize;
    GameObject player;
    float distanceToCenter;
    int damageOvertime;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerShip");
        StartCoroutine(fogDamageCoroutine());

    }

    // Update is called once per frame
    void Update()
    {
        distanceToCenter = Vector3.Distance(player.transform.position, new Vector3(0,0,0));
        if(distanceToCenter > levelSize)
        {
            float alphaMod = (distanceToCenter - levelSize)/10; 
            fog.color = new Color(0,0,0,alphaMod);
            fogText.color = new Color(255,255,255,alphaMod);
        }
        else
        {
            fog.color = new Color(0,0,0,0);
            fogText.color = new Color(255,255,255,0);

        }
    }
    IEnumerator fogDamageCoroutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            if(distanceToCenter > levelSize+5)
            {
                characterController playerScrpt = player.GetComponent<characterController>();
                playerScrpt.HP--;
            }
        }
    }
}
