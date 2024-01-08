using UnityEngine;

public class EnemyHitController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            DestroyProjectile();
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Player"))
        {
            DestroyProjectile();
            collision.gameObject.SetActive(false);
        }
    }

    private void DestroyProjectile()
    {
        gameObject.SetActive(false);
    }
}
