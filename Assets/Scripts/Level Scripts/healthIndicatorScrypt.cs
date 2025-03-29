using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class healthIndicatorScrypt : MonoBehaviour
{
    public TextMeshProUGUI TextUI;
    healthManager PlyrHpScript;
    public deathScreen DScreen;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("PlayerShip");
        PlyrHpScript = player.GetComponent<healthManager>();
    }

    void Update()
    {
        TextUI.SetText("HP: " + PlyrHpScript.hp.ToString());
        if(PlyrHpScript.hp <= 0)
        {
            DScreen.Activate();
        }
    }
}
