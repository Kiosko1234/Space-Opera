using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class creditsScript : MonoBehaviour
{

    public void Quit()
    {
        Application.Quit();
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("TitleScreen");
    }

}
