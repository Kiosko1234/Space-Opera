using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int gameProgression;
    public int shipProgression;
    public SerializableDictionary<int, bool> levelsBeaten;

    public GameData()
    {
        this.gameProgression = 0;
        shipProgression = 0;
        levelsBeaten = new SerializableDictionary<int, bool>();
    }
}
