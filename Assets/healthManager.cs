using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthManager : MonoBehaviour
{
    public int hp;
    public bool isEnemy;
    public bool isPlayer;
    public bool isObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
        {
            Die();
        }
    }

    public void Damage(int incomingDamage) //take damage
    {
        hp -= incomingDamage;
    }

    public void Die()
    {
        if(isEnemy)
        {
            levelManager.completion++;
            Destroy(this.gameObject);
        }
    }
}
