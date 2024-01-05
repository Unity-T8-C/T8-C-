using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] itemPrefabs;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            OnDie();
        }
    }


    public void OnDie()
    {       
        SpawnItem();
        Destroy(gameObject);
    }
    
    private void SpawnItem()
    {
        
        int spawnItem = Random.Range(0, 100);
        if (spawnItem < 10)
        {
            Instantiate(itemPrefabs[1], transform.position, Quaternion.identity);
        }
        
    }
}
