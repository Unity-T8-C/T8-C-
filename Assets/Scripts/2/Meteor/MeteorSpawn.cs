using System.Collections;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class MeteoriteSpawner : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;
    [SerializeField]
    private GameObject alertLinePrefab;
    [SerializeField]
    private GameObject meteoritePrefab;
    [SerializeField]
    private float minSpawnTime = 1.0f;
    [SerializeField]
    private float maxSpawnTime = 4.0f;

    private void Awake()
    {
        StartCoroutine("SpawnMeteorite");
    }

    private IEnumerator SpawnMeteorite()
    {
        while (true)
        {
            // x ��ġ�� ���������� ũ�� ���� ������ ������ ���� ����
            float positionX = Random.Range(stageData.LimitMin.x, stageData.LimitMax.x);
            // ��� ������Ʈ ����
            GameObject alertLineClone = Instantiate(alertLinePrefab, new Vector3(positionX, 0, 0), Quaternion.identity);

            // 1�ʰ� ���
            yield return new WaitForSeconds(1.0f);

            // ��� ������Ʈ ����
            Destroy(alertLineClone);

            // ���׿� ������Ʈ ����
            Vector3 meteoritePosition = new Vector3(positionX, stageData.LimitMax.y + 1.0f, 0);
            Instantiate(meteoritePrefab, meteoritePosition, Quaternion.identity);

            // ��� �ð� ���� (minSpawnTime ~ maxSpawnTime)
            float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            // �ش� �ð���ŭ ��� �� ���� ���� ����
            yield return new WaitForSeconds(spawnTime);
        }
    }
}