using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    [SerializeField]
    private ShipSO CurShip;
    public GameObject[] ShipPrefabs;
    
    void Awake()
    {
        if(CurShip.Ship == "Scrap")
        {
            Instantiate(ShipPrefabs[0], new Vector3(0,0,0), new Quaternion(0,0,0,0));
        }
        else if(CurShip.Ship == "Medium")
        {
            Instantiate(ShipPrefabs[1], new Vector3(0,0,0), new Quaternion(0,0,0,0));
        }
        else if(CurShip.Ship == "Small")
        {
            Instantiate(ShipPrefabs[2], new Vector3(0,0,0), new Quaternion(0,0,0,0));
        }
        else if(CurShip.Ship == "Big")
        {
            Instantiate(ShipPrefabs[3], new Vector3(0,0,0), new Quaternion(0,0,0,0));
        }

    }
    void Start()
    {
        Time.timeScale = 1f;        
    }


}
