using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public levelSelectMenu LevelSelectMenuScript;
    void Start()
    {
        deathScreen.DeathScreenIsActive = false;
    }
    void Update()
    {
        if(deathScreen.DeathScreenIsActive) //if the deathscreen isnt active allow pause menu to work
        {
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                if(GameIsPaused)
                {
                    Resume();
                }
                else if (levelSelectMenu.MenuOpened && LevelSelectMenuScript != null)
                {
                    LevelSelectMenuScript.CloseMenu();
                }
                else
                {
                    Pause();
                }
            }    
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void LoadSettings()
    {
        Debug.Log("initiating settings presidure");  
    }
    public void QuitGame()
    {
        Debug.Log("Quitting");
        SceneManager.LoadScene("TitleScreen");
    }
}
