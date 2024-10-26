using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform player;
    public Vector3 distancebetweencameraandplayer;
    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + distancebetweencameraandplayer;
    }
}