using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class progressionController : MonoBehaviour
{
    public MoonInfoSO moonInfo;
    public ShipSO shipInfo;
    public levelManager levelManager;
    public bool showReward;

    public void Progress()
    {
        if(moonInfo.MoonFreed[levelManager.levelNumber] == false) //if this moon hasnt been beaten yet then give them the reward
        {
            showReward = true;
            moonInfo.MoonFreed[levelManager.levelNumber] = true;
            shipInfo.GameProgression++;
            if(shipInfo.GameProgression == 1 || shipInfo.GameProgression == 2 || shipInfo.GameProgression == 3) //the reward, please rework later
            {
                shipInfo.ShipProgression++;
            }
        }
        else
        {
            showReward = false;
        }
    }

    void Update() {
        //this is just so it can be disabled in the inspector
    }
}
