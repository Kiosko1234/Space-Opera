using System.Collections;
using System.Collections.Generic;
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

    public string SelectedLevel;


    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.L))
        // {
        //     OpenMenu("a", "a", null);
        // }
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
        SceneManager.LoadScene(sceneName:SelectedLevel);
    }
}
