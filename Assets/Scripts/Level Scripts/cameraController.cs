using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform player;
    public Vector3 distancebetweencameraandplayer;

    void Start()
    {
        GameObject PInstance = GameObject.FindGameObjectWithTag("PlayerShip");
        player = PInstance.GetComponent<Transform>();
    }

    void Update()
    {
        transform.position = player.position + distancebetweencameraandplayer;
    }
}