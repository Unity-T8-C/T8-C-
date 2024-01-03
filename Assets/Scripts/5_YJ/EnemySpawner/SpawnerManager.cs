using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public GameObject[] enemyObjs;
    public Transform[] spawnPoints;

    public float maxspawnDelay;
    public float curspawnDelay;

    private void Update()
    {
        curspawnDelay += Time.deltaTime;

        if(curspawnDelay>maxspawnDelay)
        {
            SpawnEnemy();
            maxspawnDelay = Random.Range(0.5f, 3f);
                curspawnDelay = 0;      //다시 초기화
        }
    }

    void SpawnEnemy()
    {
        int ranEnemy = Random.Range(0, 3);
        int ranPoint = Random.Range(0, 5);
        Instantiate(enemyObjs[ranEnemy],
            spawnPoints[ranPoint].position,
                spawnPoints[ranPoint].rotation);
    }
}
