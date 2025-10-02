using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public GameObject minmap;
    Camera objektiv;
    deathFog df; //150
    void Start()
    {
        //     minmap = GameObject.FindGameObjectWithTag("Minimap");
        objektiv = this.gameObject.GetComponent<Camera>();
        df = GameObject.FindGameObjectWithTag("Canvas").GetComponent<deathFog>();
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
