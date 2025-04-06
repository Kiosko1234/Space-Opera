using System.Collections;
using System.Collections.Generic;
// using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    [SerializeField]
    private ShipSO CurShip;
    public GameObject[] ShipPrefabs;
    public GameObject MinmapIconPrefab;
    
    void Awake()
    { //spawn the ship the player has selected
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
        GameObject MinmapIcon = Instantiate(MinmapIconPrefab, new Vector3(0,0,0), new Quaternion(0,0,0,0));
        MinmapIcon.transform.SetParent(GameObject.FindGameObjectWithTag("PlayerShip").transform);
        MinmapIcon.transform.localPosition = Vector3.zero;

    }
    void Start()
    { 
        Time.timeScale = 1f;        
    }


}
