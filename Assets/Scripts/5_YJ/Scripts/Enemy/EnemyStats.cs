using System;
using UnityEngine;

public enum StatsChangeType
{
    Add,
    Override
}

[Serializable]
public class EnemyStats
{
    public StatsChangeType statsChangeType;

    [Range(1, 1000)] public int maxHp;
    [Range(1.0f, 20.0f)] public float moveSpeed;

    public int attackDamage;
    public float attackDelay;
    public int bossHp;

    public EnemySO enemySO;
}
