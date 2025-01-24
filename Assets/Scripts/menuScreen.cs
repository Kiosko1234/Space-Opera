using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScreen : MonoBehaviour
{
    public ShipSO shipSO;
    public void StartButton()
    {
        if(shipSO.GameProgression == 0)
        {
            SceneManager.LoadScene("Cutscene");
        }
        else
        {
            SceneManager.LoadScene("LevelSelect");
        }
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
