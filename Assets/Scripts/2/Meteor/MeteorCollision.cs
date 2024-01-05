using UnityEngine;

public class Meteorite : MonoBehaviour
{
    [SerializeField]
    private int damage = 5;         // 운석 공격력
    [SerializeField]
    private GameObject explosionPrefab; // 폭발 효과

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            // 운석 공격력만큼 플레이어 체력 감소
            // collision.GetComponent<PlayerHP>().TakeDamage(damage);
            // 운석 삭제
            OnDie();
        }
    }

    public void OnDie()
    {
        // 폭발 이펙트 생성
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        // 운석 삭제
        Destroy(gameObject);
    }

}