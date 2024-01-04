using UnityEngine;

public class BossEnemyAttackController : MonoBehaviour
{
    [SerializeField] private LayerMask CollisionLayer;

    private BossEnemyData _bossData;
    private float _currentDuration;
    private Vector2 _direction;
    private bool _isReady;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private ProjectileManager _projectileManager;

    public bool fxOnDestory = true;

    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!_isReady)
        {
            return;
        }

        _currentDuration += Time.deltaTime;
        if (_currentDuration > _bossData.duration)
        {
            DestroyProjectile();
        }

        _rigidbody.velocity = _direction * _bossData.atkSpeed;
    }

    public void BossInitializeAttack(Vector2 direction, BossEnemyData bossData, ProjectileManager projectileManager)
    {
        _projectileManager = projectileManager;
        _bossData = bossData;
        _direction = direction;

        UpdateProjectilSprite();
        _currentDuration = 0;

        transform.right = _direction;

        _isReady = true;
    }

    private void UpdateProjectilSprite()
    {
        transform.localScale = Vector3.one * _bossData.size;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // player 와 부딪혔을 때 어떻게 처리 할 것인지 ( HP )
        if (collision.CompareTag("Player"))
        {
            DestroyProjectile();
        }
    }

    private void DestroyProjectile()
    {
        gameObject.SetActive(false);
    }
}
