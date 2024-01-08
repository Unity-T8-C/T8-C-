using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    private static ProjectileManager _instance;

    private ObjectPool objectPool;

    public static ProjectileManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject pm = new GameObject("ProjectileManager");
                pm.AddComponent<ProjectileManager>();
                _instance = pm.GetComponent<ProjectileManager>();
                DontDestroyOnLoad(pm);
            }
            return _instance;
        }
        set
        {
            if (_instance == null) _instance = value;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (_instance != this) Destroy(this);
        }
    }

    private void Start()
    {
        objectPool = GetComponent<ObjectPool>();
    }

    public void ShootBullet(Vector2 startPosition, Vector2 direction, RangedEnemyData rangedData)
    {
        GameObject obj = objectPool.SpawnFromPool(rangedData.projectileNameTag);

        obj.transform.position = startPosition;
        RangedAttackController attackController = obj.GetComponent<RangedAttackController>();
        attackController.InitializeAttack(direction, rangedData, this);

        Debug.Log("ShootBullet");
        obj.SetActive(true);
    }

    public void BossEnemyAttacking(int level, Vector2 startPosition, Vector2 direction, BossEnemyData bosssData, float speed)
    {
        if (level < 1 || level > bosssData.projectileNameTags.Length)
        {
            return;
        }

        string projectileNameTag = bosssData.projectileNameTags[level - 1];
        GameObject obj = objectPool.SpawnFromPool(projectileNameTag);

        obj.transform.position = startPosition;
        BossEnemyAttackController attackController = obj.GetComponent<BossEnemyAttackController>();
        attackController.BossInitializeAttack(direction, speed, bosssData, this);

        obj.SetActive(true);
    }

    public void BossEnemySpawn(Transform startPosition, BossEnemyData bossData)
    {
        if (startPosition == null)
        {
            return;
        }

        GameObject obj = objectPool.SpawnFromPool(bossData.spawnEnemyTag);

        if (obj == null)
        {
            return;
        }

        obj.transform.position = startPosition.position;

        ContactEnemyController enemyController = obj.GetComponent<ContactEnemyController>();
        if (enemyController != null)
        {
            enemyController.EnemySpawn(bossData, this);
            Debug.Log("SpawnEnemy");
            obj.SetActive(true);
        }
    }

    public void ResetProjectiles()
    {
        GameObject[] activeProjectiles = GameObject.FindGameObjectsWithTag("Projectile");

        foreach (GameObject projectile in activeProjectiles)
        {
            projectile.SetActive(false);
        }
    }
}
