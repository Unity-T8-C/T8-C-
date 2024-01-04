using UnityEngine;

public class EnemyStatsHandler : MonoBehaviour
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
    }
}
