using System.Collections;
using UnityEditor;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class BossEnemyShooting : MonoBehaviour
{
    private EnemyController Controller;
    [SerializeField] private Transform projectileAttackPosLevel1;
    [SerializeField] private Transform projectileAttackPosLevel2;
    [SerializeField] private Transform projectileAttackPosLevel3;
    [SerializeField] protected Transform enemySpawnPos;
    [SerializeField] protected Transform enemySpawnPos2;

    [SerializeField]
    private GameObject alertLinePrefab;
    [SerializeField]
    private GameObject laserPrefab;
    [SerializeField] private Transform laserPos;

    private float laserDelay = 7.0f;
    private bool laserDelayCheck;

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
        laserDelayCheck = true;
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
            float speed = bossData.atkSpeed;

            float randomSpread = Random.Range(-bossData.spread, bossData.spread);
            angle += randomSpread;

            CreateProjectile(bossData, angle, speed);

            if (stats.CurrentStats.maxHp <= 700)
            {
                bossData.atkDelay = 3.0f;
                speed = 5.0f;
                numberOfProjectilesPerShot = 2;
                CreateProjectile(bossData, angle, speed);
            }
            else if (stats.CurrentStats.maxHp <= 500)
            {
                bossData.atkDelay = 2.0f;
                speed = 7.0f;
                projectilesAngleSpace = Random.Range(0, 50);
                numberOfProjectilesPerShot = 4;
                CreateProjectile(bossData, angle, speed);
            }
            if (stats.CurrentStats.maxHp <= 300)
            {
                bossData.atkDelay = 0.5f;
                speed = 3.0f;
                projectilesAngleSpace = Random.Range(0, 120);
                numberOfProjectilesPerShot = 8;
                CreateProjectile(bossData, angle, speed);
            }
        }

        if (stats.CurrentStats.maxHp <= 250 && laserDelayCheck)
        {
            StartCoroutine("LaserAttack");
        }
    }

    private void CreateProjectile(BossEnemyData bossData, float angle, float speed)
    {
        _projectileManager.BossEnemyAttacking(1, projectileAttackPosLevel1.position,
                                       Rotate(_aimDirection, angle), bossData, speed);

        if (stats.CurrentStats.maxHp <= 500)
        {
            _projectileManager.BossEnemyAttacking(2, projectileAttackPosLevel2.position,
                                       Rotate(_aimDirection, angle), bossData, speed);
        }

        if (stats.CurrentStats.maxHp <= 300 && spawnDelay)
        {
            _bossData = bossData;
            Invoke("SpawnEnemy", 5.0f);
            spawnDelay = false;
        }

        if (stats.CurrentStats.maxHp <= 100)
        {
            _projectileManager.BossEnemyAttacking(3, projectileAttackPosLevel3.position,
                                       Rotate(_aimDirection, angle), bossData, speed);
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
            if(stats.CurrentStats.maxHp <= 200)
            {
                _projectileManager.BossEnemySpawn(enemySpawnPos2, _bossData);
            }
        }
        Debug.Log("근접 공격체 소환");
    }

    private IEnumerator LaserAttack()
    {
        while (true)
        {
            laserDelayCheck = false;

            GameObject laserLine = Instantiate(alertLinePrefab, new Vector3(-0.17f, 0, 0), Quaternion.identity);

            yield return new WaitForSeconds(3.0f);

            Destroy(laserLine);

            laserPrefab.SetActive(true);

            yield return new WaitForSeconds(1.0f);
            laserPrefab.SetActive(false);

            yield return new WaitForSeconds(laserDelay);
            laserDelayCheck = true;
        }
    }
}