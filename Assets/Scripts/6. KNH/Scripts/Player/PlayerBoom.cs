using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoom : MonoBehaviour
{
    public GameObject boomPrefab;
    public Transform boomSpawnPoint;
    public GameObject explosionEffectPrefab;

    public float bombSpeed = 10f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireBoom();
        }
    }

    void FireBoom()
    {
        GameObject bomb = Instantiate(boomPrefab, boomSpawnPoint.position, Quaternion.identity);

        Rigidbody2D bombRb = bomb.GetComponent<Rigidbody2D>();
        bombRb.velocity = new Vector2(0, bombSpeed);

        GameObject explosionEffect = Instantiate(explosionEffectPrefab, boomSpawnPoint.position, Quaternion.identity);
        Destroy(explosionEffect, 1f);
        
    }
}