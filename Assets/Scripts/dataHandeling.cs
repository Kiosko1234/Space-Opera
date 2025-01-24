using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class dataHandeling : MonoBehaviour, IDataPersistance
{
    public ShipSO shipSO;
    public MoonInfoSO moonInfoSO;

    public void LoadData(GameData data)
    {
        this.shipSO.GameProgression = data.gameProgression;
        this.shipSO.ShipProgression = data.shipProgression;
        for(int k = 0; k < moonInfoSO.MoonFreed.Length; k++)
        {
            data.levelsBeaten.TryGetValue(k, out moonInfoSO.MoonFreed[k]);
        }
    }
    public void SaveData(GameData data)
    {
        data.gameProgression = this.shipSO.GameProgression;
        data.shipProgression = this.shipSO.ShipProgression;

        for(int k = 0; k < moonInfoSO.MoonFreed.Length; k++)
        {
            if(data.levelsBeaten.ContainsKey(k))
            {
                data.levelsBeaten.Remove(k);
            }
            data.levelsBeaten.Add(k, moonInfoSO.MoonFreed[k]);
        }
    }
}
