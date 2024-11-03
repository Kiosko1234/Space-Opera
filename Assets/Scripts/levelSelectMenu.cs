using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelSelectMenu : MonoBehaviour
{
    public static bool MenuOpened = false;
    public GameObject LevelSelectionUI;
    public TextMeshProUGUI PlanetNameUItext;
    public TextMeshProUGUI StatusUItext;
    public TextMeshProUGUI SelectedShipUI;
    public TextMeshProUGUI flavourText;

    public string SelectedLevel;
    public string[] UlockShipdex;
    private int ShipSelector = 0;
    public RawImage ShipSelectorImage;
    public Texture2D[] ShipImages;

    [SerializeField]
    private ShipSO CurShip;

    
    void Start()
    { //loading the selection of ships, needs to be made automatic through files later
        UlockShipdex = new string[CurShip.ShipProgression+1];
        if(CurShip.ShipProgression >= 0)
        {
            UlockShipdex[0] = "Scrap";
        }
        if(CurShip.ShipProgression >= 1)
        {
            UlockShipdex[1] = "Medium";
        }
        if(CurShip.ShipProgression >= 2)
        {
            UlockShipdex[2] = "Small";
        }
        if(CurShip.ShipProgression >= 3)
        {
            UlockShipdex[3] = "Big";
        }

        MenuOpened = false;  
    }
    void Update()
    {
        SelectedShipUI.SetText(UlockShipdex[ShipSelector]);
        //please make this better in the future, i just dont have time rn
        if(UlockShipdex[ShipSelector] == "Scrap")
        {
            ShipSelectorImage.texture = ShipImages[0];
        }
        if(UlockShipdex[ShipSelector] == "Medium")
        {
            ShipSelectorImage.texture = ShipImages[1];
        }
        if(UlockShipdex[ShipSelector] == "Small")
        {
            ShipSelectorImage.texture = ShipImages[2];
        }
        if(UlockShipdex[ShipSelector] == "Big")
        {
            ShipSelectorImage.texture = ShipImages[3];
        }
    }

    public void OpenMenu(string NameOfPlanet, string StatusOfPlanet, string Level, string planetInfo)
    {
        LevelSelectionUI.SetActive(true);
        Time.timeScale = 0f;
        MenuOpened = true;
        PlanetNameUItext.SetText(NameOfPlanet);
        StatusUItext.SetText("Status: " + StatusOfPlanet);
        SelectedLevel = Level;
        flavourText.SetText(planetInfo);
        
    }
    public void CloseMenu()
    {
        LevelSelectionUI.SetActive(false);
        Time.timeScale = 1f;
        MenuOpened = false;
    }
    
    public void StartLevel()
    {
        if(StatusUItext.text != "Locked")
        {
            CurShip.Ship = UlockShipdex[ShipSelector];
            SceneManager.LoadScene(sceneName:SelectedLevel);

        }
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
