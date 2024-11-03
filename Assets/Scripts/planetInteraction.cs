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
    public ShipSO shipSO;
    public string planetInfo;
    public int progressRequirement;


    void Start()
    {
        if(moonInfo.MoonFreed[levelNumber] == true)
        {
            status = "Liberated";
        }
        else if(progressRequirement <= shipSO.GameProgression)
        {
            status = "Locked";
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
            levelSelectMenuScript.OpenMenu(planetName, status, level, planetInfo);
        }
    }

}
