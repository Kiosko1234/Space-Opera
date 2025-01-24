using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ShipSO : ScriptableObject
{
    [SerializeField]
    private string _ship;

    [SerializeField]
    private int _shipProgression;

    [SerializeField]
    private int _gameProgression;

    public string Ship
    {
        get { return _ship; }
        set { _ship = value; }
    }

    public int ShipProgression
    {
        get{return _shipProgression; }
        set{_shipProgression = value; }
    }

    public int GameProgression
    {
        get{return _gameProgression; }
        set{_gameProgression = value; }
    }
}
