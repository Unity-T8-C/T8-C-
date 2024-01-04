using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyStatsHandler : MonoBehaviour
{
    [SerializeField] private EnemyStats baseStats;
    public EnemyStats CurrentStats { get; private set; }

    private void Awake()
    {
        UpdateStats();
    }

    private void UpdateStats()
    {
        EnemySO enemySO = null;
        if (baseStats.enemySO != null)
        {
            enemySO = Instantiate(baseStats.enemySO);
        }

        CurrentStats = new EnemyStats { enemySO = enemySO };

        CurrentStats.statsChangeType = baseStats.statsChangeType;
        CurrentStats.maxHp = baseStats.maxHp;
        CurrentStats.moveSpeed = baseStats.moveSpeed;

        if (enemySO != null)
        {
            CurrentStats.attackDamage = enemySO.isBoss ? enemySO.bossAtk : enemySO.atk;
            CurrentStats.attackDelay = enemySO.isBoss ? enemySO.bossAtkDelay : enemySO.atkDelay;

            if (enemySO.isBoss)
            {
                CurrentStats.bossHp = enemySO.bossHp;
            }
        }
    }

    //public void TakeDamage(int damageAmount)
    //{
    //    CurrentStats.maxHp -= damageAmount;

    //    if (CurrentStats.maxHp <= 0)
    //    {
    //        Die();
    //    }
    //}

    //private void Die()
    //{
    //    Destroy(gameObject);
    //}
}
