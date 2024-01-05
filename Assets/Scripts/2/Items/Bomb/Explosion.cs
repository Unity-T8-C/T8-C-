using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    private GameObject boomPrefab;          // ��ź ������
    private int boomCount = 3;		// ���� ������ ��ź
   
    public void StartBoom()
    {
        if (boomCount > 0)
        {
            boomCount --;
            Instantiate(boomPrefab, transform.position, Quaternion.identity);
        }
    }
    public int BoomCount
    {
        set => boomCount = Mathf.Max(0, value);
        get => boomCount;
    }
}
