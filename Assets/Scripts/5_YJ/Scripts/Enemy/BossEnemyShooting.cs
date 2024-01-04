using UnityEngine;

public class BossEnemyShooting : MonoBehaviour
{
    private EnemyController Controller;
    [SerializeField] private Transform projectileAttackPosLevel1;
    [SerializeField] private Transform projectileAttackPosLevel2;
    [SerializeField] private Transform projectileAttackPosLevel3;
    [SerializeField] protected Transform enemySpawnPos;
    [SerializeField] protected Transform enemySpawnPos2;

    private Vector2 _aimDirection = Vector2.right;
    private ProjectileManager _projectileManager;

    protected EnemyStatsHandler stats;
    protected BossEnemyData _bossData;

    public bool spawnDelay;

    private void Awake()
    {
        Controller = GetComponent<EnemyController>();
        stats = GetComponent<EnemyStatsHandler>();
        _bossData = new BossEnemyData();

        spawnDelay = true;
    }

    private void Start()
    {
        _projectileManager = ProjectileManager.Instance;
        Controller.OnAttackEvent += OnAttack;
        Controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 aimDirection)
    {
        _aimDirection = aimDirection;
    }

    private void OnAttack(EnemySO enemySO)
    {
        BossEnemyData bossData = enemySO as BossEnemyData;

        float projectilesAngleSpace = bossData.multipleProjectilesAngel;
        int numberOfProjectilesPerShot = bossData.numberofProjectilesPerShot;

        float minAngle = -(numberOfProjectilesPerShot / 2f) * projectilesAngleSpace + 0.5f * bossData.multipleProjectilesAngel;

        for (int i = 0; i < numberOfProjectilesPerShot; i++)
        {
            float angle = minAngle + projectilesAngleSpace * i;
            float randomSpread = Random.Range(-bossData.spread, bossData.spread);
            angle += randomSpread;
            CreateProjectile(bossData, angle);
            Debug.Log("OnAttack");
        }
    }

    private void CreateProjectile(BossEnemyData bossData, float angle)
    {
        Debug.Log("CreateProjectile");
        _projectileManager.BossEnemyAttacking(projectileAttackPosLevel1.position,
                                       Rotate(_aimDirection, angle), bossData);

        if (stats.CurrentStats.maxHp <= 500)
        {
            _projectileManager.BossEnemyAttackingLevel2(projectileAttackPosLevel2.position,
                                       Rotate(_aimDirection, angle), bossData);
        }

        if (stats.CurrentStats.maxHp <= 300 && spawnDelay)
        {
            _bossData = bossData;
            Invoke("SpawnEnemy", 5.0f);
            spawnDelay = false;
        }

        if (stats.CurrentStats.maxHp <= 100)
        {
            _projectileManager.BossEnemyAttackingLevel3(projectileAttackPosLevel3.position,
                                       Rotate(_aimDirection, angle), bossData);
            _projectileManager.BossEnemySpawn(enemySpawnPos2, bossData);
        }
    }

    private static Vector2 Rotate(Vector2 v, float degree)
    {
        return Quaternion.Euler(0, 0, degree) * v;
    }

    private void SpawnEnemy()
    {
        if (_bossData != null)
        {
            _projectileManager.BossEnemySpawn(enemySpawnPos, _bossData);
            _bossData = null;
            spawnDelay = true;
        }
        Debug.Log("근접 공격체 소환");
    }
}
