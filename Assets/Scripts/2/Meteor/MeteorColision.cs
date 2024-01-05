using UnityEngine;

public class Meteorite : MonoBehaviour
{
    [SerializeField]
    private int damage = 5;         // � ���ݷ�
    [SerializeField]
    private GameObject explosionPrefab; // ���� ȿ��

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            // � ���ݷ¸�ŭ �÷��̾� ü�� ����
            // collision.GetComponent<PlayerHP>().TakeDamage(damage);
            // � ����
            //DeletMeteor();
            Destroy(collision.gameObject);
        }
    }

    public void DeletMeteor()
    {
        // ���� ����Ʈ ����
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        // � ����
        Destroy(gameObject);
    }
}