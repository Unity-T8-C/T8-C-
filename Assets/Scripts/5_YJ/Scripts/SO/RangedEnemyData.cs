using UnityEngine;

[CreateAssetMenu(fileName = "RangedEnemyData", menuName = "Enemys/RangedEnemy")]
public class RangedEnemyData : EnemySO
{
    [Header("Ranged Enemy Data")]
    public string projectileNameTag;

    public float duration;
    public float atkSpeed;
    public float size;
}
