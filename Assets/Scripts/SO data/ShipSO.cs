using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ShipSO : ScriptableObject
{
    [SerializeField]
    private string _ship;
    public string Ship
    {
        get { return _ship; }
        set { _ship = value; }
    }
    
}
