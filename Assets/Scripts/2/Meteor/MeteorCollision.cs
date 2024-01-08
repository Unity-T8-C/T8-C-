using UnityEngine;

public class Meteorite : MonoBehaviour
{
   
    [SerializeField]
    private GameObject explosionPrefab; // ���� ȿ��

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
        // ���� ����Ʈ ����
        //Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        // � ����
        Destroy(gameObject);
    }

}