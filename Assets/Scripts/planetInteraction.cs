using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class planetInteraction : MonoBehaviour
{
    public string PlanetName;
    public bool Liberated;
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
            LevelSelectMenuScript.OpenMenu(PlanetName, Liberated, Level);
        }
    }

    public void Save(ref PlanetSaveData data)
    {
        data.isLiberated = Liberated;
    }

    public void Load(PlanetSaveData data)
    {
        Liberated = data.isLiberated;
    }
}

[System.Serializable]
public struct PlanetSaveData
{
    public bool isLiberated;
}
