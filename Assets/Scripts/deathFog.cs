using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class deathFog : MonoBehaviour
{
    public GameObject fogject;
    public Image fog;
    public TextMeshProUGUI fogText;
    public float levelSize;
    GameObject player;
    float distanceToCenter;
    int damageOvertime;

    // Start is called before the first frame update
    void Start()
    {
        fogject.SetActive(false);
        player = GameObject.FindGameObjectWithTag("PlayerShip"); //find player
        StartCoroutine(fogDamageCoroutine());

    }

    // Update is called once per frame
    void Update()
    {
        distanceToCenter = Vector3.Distance(player.transform.position, new Vector3(0,0,0)); 
        if(distanceToCenter > levelSize) //if the player is out of bounds
        {
            fogject.SetActive(true);
            float alphaMod = (distanceToCenter - levelSize)/10; 
            fog.color = new Color(0,0,0,alphaMod);
            fogText.color = new Color(255,255,255,alphaMod);
        }
        else //if the player isnt out of bounds
        {
            fogject.SetActive(false);
            fog.color = new Color(0,0,0,0);
            fogText.color = new Color(255,255,255,0);

        }
    }
    IEnumerator fogDamageCoroutine() //damage every second if you are out of bounds
    {
        while(true)
        {
            yield return new WaitForSeconds(1); //do not move this into the if, it will break unity
            if(distanceToCenter > levelSize+5)
            {
                characterController playerScrpt = player.GetComponent<characterController>();
                playerScrpt.HP--;
            }
        }
    }
}
