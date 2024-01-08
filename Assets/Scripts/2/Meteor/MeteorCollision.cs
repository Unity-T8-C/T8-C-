using UnityEngine;

public class Meteorite : MonoBehaviour
{
   
    [SerializeField]
    private GameObject explosionPrefab; // 气惯 瓤苞

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {           
            Destroy(collision.gameObject);
            OnDie();
            GameManager.Instance.PlayerDie();
        }
    }

    public void OnDie()
    {
        // 气惯 捞棋飘 积己
        //Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        // 款籍 昏力
        Destroy(gameObject);
    }

}