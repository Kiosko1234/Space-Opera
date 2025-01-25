using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public GameObject minmap;
    void Start()
    {
   //     minmap = GameObject.FindGameObjectWithTag("Minimap");
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            if(minmap.activeSelf == true)
            {
                minmap.SetActive(false);
            }
            else
            {
                minmap.SetActive(true);
            }

        }

    }
}
