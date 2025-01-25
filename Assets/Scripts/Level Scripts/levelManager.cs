using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class levelManager : MonoBehaviour
{
    public int levelNumber;
    public int progression = 0;
    public static int completion = 0;
    private int completionTarget;
    public GameObject[] enemyBank;
    public Transform[] spawnPos;
    public float delay;
    public int spawnRate;
    public int initialSpawn;
    public winScreen winUI;
    public progressionController progressionController;
    public GameObject minmapIconPrefab;
    
    void Update() 
    {
        if (completion >= completionTarget)
        {
            Win();
        }
    }
    void Start()
    {
        completionTarget = enemyBank.Length;
        progression = 0;
        completion = 0;

        Spawn(initialSpawn);
        
        StartCoroutine(spawnTimerCoroutine());
    }
    IEnumerator spawnTimerCoroutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(delay);
            Spawn(spawnRate);
        }
    }


    void Spawn(int Count)
    {
        for (int k=0;  k < Count; k++)
        {
            if(progression < completionTarget)
            {
                GameObject thisEnemy = Instantiate(enemyBank[progression], spawnPos[Random.Range(0,spawnPos.Length)].position+new Vector3(Random.Range(-2f,2f),Random.Range(-2f,2f),0), new Quaternion(0,0,0,0));
                progression++;
                GameObject MinmapIcon = Instantiate(minmapIconPrefab, new Vector3(0,0,0), new Quaternion(0,0,0,0));
                MinmapIcon.transform.SetParent(thisEnemy.transform);
                MinmapIcon.transform.localPosition = Vector3.zero;

            }
        }
    }
    void Win()
    {
        progressionController.Progress();
        winUI.Activate(progressionController.showReward);
    }
}
