using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldDetection : MonoBehaviour
{
    public static Collider2D collis; //collision but i dont want to repeat names

    void OnTriggerEnter2D(Collider2D collision)
    {
        collis = collision;
    }

}
