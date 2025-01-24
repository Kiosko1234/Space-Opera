using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winScreen : MonoBehaviour
{
    public static bool WinScreenIsActive = false;
    public GameObject WinScreenUI;

    void Start()
    {
        WinScreenIsActive = false;
    }

    public void Activate(bool firstTime)
    {
        WinScreenIsActive = true;
        WinScreenUI.SetActive(true);
        Time.timeScale = 0f;
        if(!firstTime)
        {
            GameObject reward = GameObject.FindGameObjectWithTag("GottenRewardIndicator");
            reward.SetActive(false);
        }
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Good try");
    }
    public void GoToLevelSelect()
    {
        WinScreenIsActive = false;
        SceneManager.LoadScene(sceneName:"LevelSelect");
    }
}
