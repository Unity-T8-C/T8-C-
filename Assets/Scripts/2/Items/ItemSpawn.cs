using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] itemPrefabs;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            //OnDie();
        }
    }


    public void OnDie()
    {       
        SpawnItem();
        //Destroy(gameObject);
    }
    
    private void SpawnItem()
    {
        
        int spawnItem = Random.Range(0, 10);
        if (spawnItem < 10)
        {
            Instantiate(itemPrefabs[0], transform.position, Quaternion.identity);
        }
        
    }
}
