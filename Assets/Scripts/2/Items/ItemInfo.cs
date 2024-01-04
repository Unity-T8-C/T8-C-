using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    public float speed = 5f;  // 아이템의 이동 속도
    public float angleRange = 45f;  // 아이템이 튕길 각도 범위
    // Start is called before the first frame update
    void Start()
    {
        float angle = Random.Range(-angleRange, angleRange);
        Vector2 direction = Quaternion.Euler(0, 0, angle) * Vector2.right;
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

   
}
