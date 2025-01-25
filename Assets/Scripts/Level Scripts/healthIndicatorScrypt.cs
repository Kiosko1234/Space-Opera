using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class healthIndicatorScrypt : MonoBehaviour
{
    public TextMeshProUGUI TextUI;
    characterController PlyrScript;
    public deathScreen DScreen;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("PlayerShip");
        PlyrScript = player.GetComponent<characterController>();
    }

    void Update()
    {
        TextUI.SetText("HP: " + PlyrScript.HP.ToString());
        if(PlyrScript.HP <= 0)
        {
            DScreen.Activate();
        }
    }
}
