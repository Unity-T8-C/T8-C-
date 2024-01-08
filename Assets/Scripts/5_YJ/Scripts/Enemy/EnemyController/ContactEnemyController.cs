using UnityEngine;

public class ContactEnemyController : EnemyController
{
    private BossEnemyData bossEnemyData;
    private ProjectileManager _projectileManager;

    Vector2 _direction = Vector2.zero;

    protected override void Start()
    {
        base.Start();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if(DistanceToTarget() < followRange)
        {
            _direction = DirectionToTarget();
        }

        CallMoveEvent(_direction);
        Rotate(_direction);
    }

    private void HpChange()
    {
        EnemySO enemySO = Stats.CurrentStats.enemySO;
        // bool damage = ( 캐릭터와 충돌 했을 때 캐릭터의 공격력 만큼 -)
    }

    public void EnemySpawn(BossEnemyData bossData, ProjectileManager projectileManager)
    {
        _projectileManager = projectileManager;
        bossEnemyData = bossData;
    }

    private void DestroyProjectile()
    {
        gameObject.SetActive(false);
    }
}
