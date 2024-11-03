using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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
        if(counter == 0)
        {
            headShot.texture = interComs;
        }
    }

    IEnumerator startUp()
    {
        yield return new WaitForSeconds(1);
        if(counter == -1)
        {
            counter++;
        }
    }
    
}
