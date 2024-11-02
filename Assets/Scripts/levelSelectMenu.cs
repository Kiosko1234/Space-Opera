using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelSelectMenu : MonoBehaviour
{
    public static bool MenuOpened = false;
    public GameObject LevelSelectionUI;
    public TextMeshProUGUI PlanetNameUItext;
    public TextMeshProUGUI StatusUItext;
    public TextMeshProUGUI SelectedShipUI;

    public string SelectedLevel;
    public string[] UlockShipdex;
    private int ShipSelector = 0;
    [SerializeField]
    private ShipSO CurShip;

    
    void Start()
    { //loading the selection of ships, needs to be made automatic through files later
        UlockShipdex[0] = "Scrap";
        UlockShipdex[1] = "Medium";
        UlockShipdex[2] = "Small";    
        UlockShipdex[3] = "Big";  
        MenuOpened = false;  
    }
    void Update()
    {
        SelectedShipUI.SetText(UlockShipdex[ShipSelector]);
    }

    public void OpenMenu(string NameOfPlanet, string StatusOfPlanet, string Level)
    {
        LevelSelectionUI.SetActive(true);
        Time.timeScale = 0f;
        MenuOpened = true;
        PlanetNameUItext.SetText(NameOfPlanet);
        StatusUItext.SetText("Status: " + StatusOfPlanet);
        SelectedLevel = Level;
        
    }
    public void CloseMenu()
    {
        LevelSelectionUI.SetActive(false);
        Time.timeScale = 1f;
        MenuOpened = false;
    }
    
    public void StartLevel()
    {
        CurShip.Ship = UlockShipdex[ShipSelector];
        SceneManager.LoadScene(sceneName:SelectedLevel);
    }
    public void NextShip()
    {
        if(ShipSelector < UlockShipdex.Length-1)
        {
            ShipSelector++;
        }
        else
        {
            ShipSelector = 0;
        }
    }
    public void PrevShip()
    {
        if(ShipSelector > 0)
        {
            ShipSelector--;
        }
        else
        {
            ShipSelector = UlockShipdex.Length-1;
        }
    }
}
