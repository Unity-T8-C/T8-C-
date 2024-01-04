using UnityEngine;

[CreateAssetMenu(fileName = "BossEnemyData", menuName = "Enemys/BossEnemy")]
public class BossEnemyData : EnemySO
{
    [Header("Boss Enemy Data")]
    public string projectileNameTag;
    public string projectileNameTag2;
    public string projectileNameTag3;
    public string spawnEnemyTag;

    public float duration;
    public float spread;
    public int numberofProjectilesPerShot;
    public float multipleProjectilesAngel;
    public float atkSpeed;
    public float size;
}
