using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    private GameObject boomPrefab;          // 气藕 橇府普
    private int boomCount = 3;		// 积己 啊瓷茄 气藕
   
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
