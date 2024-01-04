using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject itemPrefab;
    void OnDestroy()
    {
        SpawnItem();
    }

    void SpawnItem()
    {
        // 아이템 생성 위치
        Vector3 spawnPosition = transform.position;

        // 아이템 생성
        GameObject item = Instantiate(itemPrefab, spawnPosition, Quaternion.identity);

        // 아이템을 자식 오브젝트로 설정하여 적과 아이템의 이동을 동기화
        item.transform.parent = transform.parent;
    }
}
