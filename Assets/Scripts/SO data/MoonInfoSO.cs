using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MoonInfoSO : ScriptableObject
{
    [SerializeField]
    private bool[] _moonFreed;

    public bool[] MoonFreed
    {
        get{return _moonFreed;}
        set{_moonFreed = value;}
    }

}
