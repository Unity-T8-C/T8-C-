using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    private EnemyController Controller;
    [SerializeField] private Transform projectileAttackPos;

    private Vector2 _aimDirection = Vector2.right;
    private ProjectileManager _projectileManager;

    private void Awake()
    {
        Controller = GetComponent<EnemyController>();
    }

    void Start()
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
        RangedEnemyData rangedData = enemySO as RangedEnemyData;

        float projectilesAngleSpace = rangedData.multipleProjectilesAngel;
        int numberOfProjectilesPerShot = rangedData.numberofProjectilesPerShot;

        float minAngle = -(numberOfProjectilesPerShot / 2f) * projectilesAngleSpace + 0.5f * rangedData.multipleProjectilesAngel;

        for (int i = 0; i < numberOfProjectilesPerShot; i++)
        {
            float angle = minAngle + projectilesAngleSpace * i;
            float randomSpread = Random.Range(-rangedData.spread, rangedData.spread);
            angle += randomSpread;
            CreateProjectile(rangedData, angle);
            Debug.Log("OnAttack");
        }
    }

    private void CreateProjectile(RangedEnemyData rangedData, float angle)
    {
        Debug.Log("CreateProjectile");
        _projectileManager.ShootBullet(projectileAttackPos.position,
                                       Rotate(_aimDirection, angle),rangedData);
    }

    private static Vector2 Rotate(Vector2 v, float degree)
    {
        return Quaternion.Euler(0, 0, degree) * v;
    }
}
