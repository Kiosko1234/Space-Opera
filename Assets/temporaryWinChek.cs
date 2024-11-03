using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class temporaryWinChek : MonoBehaviour
{
    public levelManager levelManager;

    // Update is called once per frame
    void Update()
    {
        if(levelManager.completion >= levelManager.enemyBank.Length)
        {
            SceneManager.LoadScene("CreditsScreen");
        }
    }
}
