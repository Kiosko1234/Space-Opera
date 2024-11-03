using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class unlockSystem : MonoBehaviour
{
    public GameObject UIthing;
    public RawImage image;
    public TextMeshProUGUI text;
    public Texture2D[] imageIndex;
    public string[] nameIndex;
    public ShipSO shipSO;


    // Update is called once per frame
    void Update()
    {
        if(shipSO.ShipProgression == 2)
        {
            UIthing.SetActive(true);
            image.texture = imageIndex[0];
            text.SetText(nameIndex[0] + " Unlocked");
        }
        else if(shipSO.ShipProgression == 3)
        {
            UIthing.SetActive(true);
            image.texture = imageIndex[1];
            text.SetText(nameIndex[1] + " Unlocked");
        }
        else
        {
            UIthing.SetActive(false);
        }
    }
}
