using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class progressionController : MonoBehaviour
{
    public MoonInfoSO moonInfo;
    public ShipSO shipInfo;
    public levelManager levelManager;


    public void Progress()
    {
        if(moonInfo.MoonFreed[levelManager.levelNumber] == false)
        {
            moonInfo.MoonFreed[levelManager.levelNumber] = true;
            shipInfo.GameProgression++;
            if(shipInfo.GameProgression == 1 || shipInfo.GameProgression == 2 || shipInfo.GameProgression == 3)
            {
                shipInfo.ShipProgression++;
            }
        }
    }
}
