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
        // ������ ���� ��ġ
        Vector3 spawnPosition = transform.position;

        // ������ ����
        GameObject item = Instantiate(itemPrefab, spawnPosition, Quaternion.identity);

        // �������� �ڽ� ������Ʈ�� �����Ͽ� ���� �������� �̵��� ����ȭ
        item.transform.parent = transform.parent;
    }
}
