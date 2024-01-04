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
        int ranPoint = Random.Range(0, 9);
        GameObject enemy= Instantiate(enemyObjs[ranEnemy],
            spawnPoints[ranPoint].position,
                spawnPoints[ranPoint].rotation);

        Rigidbody2D rigid = enemy.GetComponent<Rigidbody2D>();
        EnemyMovement enemyLogic = enemy.GetComponent<EnemyMovement>();
        

        if(ranPoint ==5 ||ranPoint ==6)
        {
            rigid.velocity = new Vector2(enemyLogic.speed * (-1), 1);
        }
        else if(ranPoint ==7||ranPoint==8)
        {
            rigid.velocity = new Vector2(enemyLogic.speed, 1);
        }
        else
        {
            rigid.velocity = new Vector2(0,enemyLogic.speed*(-1));
        }
    }
}
