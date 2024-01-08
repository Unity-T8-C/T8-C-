using UnityEditor.U2D.Animation;
using UnityEngine;

public class BossEnemyHitController : MonoBehaviour
{
    private EnemyStatsHandler enemyStats;
    private CharacterMove characterStats;

    private int currentHp;
    private int characterAtk;

    private void Awake()
    {
        enemyStats = GetComponent<EnemyStatsHandler>();
        characterStats = GetComponentInChildren<CharacterMove>();
    }

    private void Start()
    {
        currentHp = enemyStats.CurrentStats.maxHp;

        if (characterStats != null)
        {
            characterAtk = characterStats.atk;
        }
        else
        {
            Debug.LogError("CharacterMove script not found or atk variable not defined.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            currentHp -= 50;
            Destroy(collision.gameObject);

            Debug.Log($"{currentHp}");
        }
        else if (collision.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHp -= damageAmount;
    }
}
