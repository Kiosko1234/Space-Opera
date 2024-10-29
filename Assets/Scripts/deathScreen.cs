using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathScreen : MonoBehaviour
{
    public static bool DeathScreenIsActive = false;
    public GameObject DeathScreenUI;

    void Start()
    {
        
    }

    public void Activate()
    {
        DeathScreenIsActive = true;
        DeathScreenUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Good try");
    }
    public void GoToLevelSelect()
    {
        SceneManager.LoadScene(sceneName:"LevelSelect");
    }
}
