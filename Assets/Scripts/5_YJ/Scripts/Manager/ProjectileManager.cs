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

    public void ShootBullet(Vector2 startPostiion, Vector2 direction, RangedEnemyData rangedData)
    {
        GameObject obj = objectPool.SpawnFromPool(rangedData.projectileNameTag);

        obj.transform.position = startPostiion;
        RangedAttackController attackController = obj.GetComponent<RangedAttackController>();
        attackController.InitializeAttack(direction, rangedData, this);

        Debug.Log("ShootBullet");
        obj.SetActive(true);
    }

    public void BossEnemyAttacking(Vector2 startPostiion, Vector2 direction, BossEnemyData bosssData)
    {
        GameObject obj = objectPool.SpawnFromPool(bosssData.projectileNameTag);

        obj.transform.position = startPostiion;
        BossEnemyAttackController attackController = obj.GetComponent<BossEnemyAttackController>();
        attackController.BossInitializeAttack(direction, bosssData, this);

        Debug.Log("ShootBossBullet");
        obj.SetActive(true);
    }

    public void BossEnemyAttackingLevel2(Vector2 startPostiion, Vector2 direction, BossEnemyData bosssData)
    {
        GameObject obj = objectPool.SpawnFromPool(bosssData.projectileNameTag2);

        obj.transform.position = startPostiion;
        BossEnemyAttackController attackController = obj.GetComponent<BossEnemyAttackController>();
        attackController.BossInitializeAttack(direction, bosssData, this);

        Debug.Log("ShootBossBulletLevel2");
        obj.SetActive(true);
    }

    public void BossEnemyAttackingLevel3(Vector2 startPostiion, Vector2 direction, BossEnemyData bosssData)
    {
        GameObject obj = objectPool.SpawnFromPool(bosssData.projectileNameTag3);

        obj.transform.position = startPostiion;
        BossEnemyAttackController attackController = obj.GetComponent<BossEnemyAttackController>();
        attackController.BossInitializeAttack(direction, bosssData, this);

        Debug.Log("ShootBossBulletLevel3");
        obj.SetActive(true);
    }

    public void BossEnemySpawn(Vector2 startPostiion, Vector2 direction, BossEnemyData bossData)
    {
        GameObject obj = objectPool.SpawnFromPool(bossData.spawnEnemyTag);

        obj.transform.position = startPostiion;
        ContactEnemyController enemyController = obj.GetComponent<ContactEnemyController>();
        enemyController.EnemySpawn(direction, bossData, this);

        Debug.Log("ShootBossBulletLevel3");
        obj.SetActive(true);
    }
}
