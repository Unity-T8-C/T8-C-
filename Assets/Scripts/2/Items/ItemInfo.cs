using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    public float speed = 5f;  // �������� �̵� �ӵ�
    public float angleRange = 45f;  // �������� ƨ�� ���� ����
    // Start is called before the first frame update
    void Start()
    {
        float angle = Random.Range(-angleRange, angleRange);
        Vector2 direction = Quaternion.Euler(0, 0, angle) * Vector2.right;
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

   
}
