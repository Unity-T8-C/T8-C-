using UnityEngine;

public class RangedAttackController : MonoBehaviour
{
    [SerializeField] private LayerMask CollisionLayer;

    private RangedEnemyData _rangedData;
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

        _rigidbody.velocity = _direction * _rangedData.atkSpeed;
    }

    public void InitializeAttack(Vector2 direction, RangedEnemyData attackData, ProjectileManager projectileManager)
    {
        _projectileManager = projectileManager;
        _rangedData = attackData;
        _direction = direction;

        UpdateProjectilSprite();
        _currentDuration = 0;

        transform.right = _direction;

        _isReady = true;
    }

    private void UpdateProjectilSprite()
    {
        transform.localScale = Vector3.one * _rangedData.size;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // player 와 부딪혔을 때 어떻게 처리 할 것인지 ( HP )
        if (collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }

    private void DestroyProjectile()
    {
        gameObject.SetActive(false);
    }
}
