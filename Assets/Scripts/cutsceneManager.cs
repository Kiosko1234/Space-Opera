using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class cutsceneManager : MonoBehaviour
{
    public GameObject panel;
    public Image faderImage;
    public TextMeshProUGUI textBox;
    public RawImage headShot;
    public Texture2D interComs;
    public Texture2D chep;
    public string[] dialogue;
    public int counter = -1;

    void Start()
    {
        faderImage.CrossFadeAlpha(0, 1, true);
        StartCoroutine(startUp());
    }

    void Update()
    {
        if(counter > -1 && counter < dialogue.Length)
        {
            textBox.SetText(dialogue[counter]);
        }
        if(Input.anyKeyDown == true) 
        {
            counter++;
        }
        if(counter > -1)
        {
            panel.SetActive(true);
        }  
        if(counter == 0 || counter == 4 || counter == 6 || counter == 10 || counter == 13 || counter == 16 || counter == 19 || counter == 22)
        {
            headShot.texture = interComs;
        }
        if(counter == 3 || counter == 9 || counter == 12 || counter == 15 || counter == 17 || counter == 21)
        {
            headShot.texture = chep;
        }
        if(counter >= dialogue.Length)
        {
            faderImage.CrossFadeAlpha(1,1,true);
            StartCoroutine(startUp());
        }
    }

    IEnumerator startUp()
    {
        yield return new WaitForSeconds(1);
        if(counter == -1)
        {
            counter++;
        }
        if(counter >= dialogue.Length)
        {
            SceneManager.LoadScene(sceneName:"Tutorial");
        }
    }
    
}