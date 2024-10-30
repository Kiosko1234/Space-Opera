using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class levelManager : MonoBehaviour
{
    public int Progression = 0;
    public static int Complesion = 0;
    private int CompletionTarget;
    public GameObject[] EnemyBank;
    public Transform[] SpawnPos;
    public float Delay;
    public int SpawnRate;
    public int InitialSpawn;
    public winScreen WinUI;
    
    void Update() 
    {
        if (Complesion >= CompletionTarget)
        {
            Win();
        }
    }
    void Start()
    {
        CompletionTarget = EnemyBank.Length;
        Progression = 0;
        Complesion = 0;

        for (int k=0;  k < InitialSpawn; k++)
        {
            Spawn(InitialSpawn);
        }
        StartCoroutine(spawnTimerCoroutine());
    }
    IEnumerator spawnTimerCoroutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(Delay);
            Spawn(SpawnRate);
        }
    }


    void Spawn(int Count)
    {
        for (int k=0;  k < Count; k++)
        {
            if(Progression < CompletionTarget)
            {
                Instantiate(EnemyBank[Progression], SpawnPos[Random.Range(0,SpawnPos.Length)].position+new Vector3(Random.Range(-2f,2f),Random.Range(-2f,2f),0), new Quaternion(0,0,0,0));
                Progression++;
            }
        }
    }
    void Win()
    {
        WinUI.Activate();
    }
}
