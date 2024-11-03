using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class planetInteraction : MonoBehaviour
{
    public string planetName;
    public string status;
    public string level;
    public int levelNumber;
    public levelSelectMenu levelSelectMenuScript;
    public MoonInfoSO moonInfo;

    void Start()
    {
        if(moonInfo.MoonFreed[levelNumber] == true)
        {
            status = "Liberated";
        }
        else
        {
            status = "Occupied";
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.tag == "BulletP")
        {
            levelSelectMenuScript.OpenMenu(planetName, status, level);
        }
    }

}
