using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class planetInteraction : MonoBehaviour
{
    public string PlanetName;
    public string Status;
    public string Level;
    public levelSelectMenu LevelSelectMenuScript;


    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.tag == "BulletP")
        {
            LevelSelectMenuScript.OpenMenu(PlanetName, Status, Level);
        }
    }

}
