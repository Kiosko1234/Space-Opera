using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using TMPro;
using UnityEngine;

public class areaUnlockMenu : MonoBehaviour
{
    public static bool MenuOpened = false;
    public GameObject areaUnlockUI;
    public TextMeshProUGUI SolarSystemNameUItext;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OpenMenu(string SolarSystemName)
    {
        areaUnlockUI.SetActive(true);
        Time.timeScale = 0f;
        MenuOpened = true;
        SolarSystemNameUItext.SetText("Unlock" + SolarSystemName);

    }

    public void CloseMenu()
    {
        areaUnlockUI.SetActive(false);
        Time.timeScale = 1f;
        MenuOpened = false;

    }


}
