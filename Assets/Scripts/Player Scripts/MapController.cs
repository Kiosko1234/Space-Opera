using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public GameObject minmap;
    Camera objektiv;
    deathFog df; //150
    void Start()
    {
        //     minmap = GameObject.FindGameObjectWithTag("Minimap");
        objektiv = minmap.GetComponent<Camera>();
        df = this.gameObject.GetComponent<deathFog>();
        objektiv.orthographicSize = 26 * (df.levelSize / 20);
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
