using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameManager gameManager;
    protected GameObject player;

    [SerializeField] protected SpriteRenderer mainSpriteRenderer;

    protected Transform target { get; private set; }
    protected EnemyStatsHandler Stats { get; private set; }

    public event Action<Vector2> OnMoveEvent;
    public event Action<EnemySO> OnAttackEvent;

    [SerializeField][Range(0.0f, 100.0f)] protected float followRange;
    protected bool IsAttacking { get; set; }

    protected virtual void Start()
    { 
        gameManager = GameManager.Instance; // gameManager 생성하면 추가
        target = gameManager.Player.transform;
        player = GetComponent<GameObject>();
        Stats = GetComponent<EnemyStatsHandler>();
    }

    protected virtual void FixedUpdate()
    {
        
    }

    private void AttackDelay()
    {
        if (Stats.CurrentStats.enemySO == null) return;
    }

    protected float DistanceToTarget() // 표적까지의 거리
    {
        return Vector3.Distance(transform.position, target.position);
    }

    protected Vector2 DirectionToTarget() // 표적 방향
    {
        return (target.position - transform.position).normalized;
    }

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallAttackEvent(EnemySO enemySO)
    {
        OnAttackEvent?.Invoke(enemySO);
    }

    protected void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        mainSpriteRenderer.flipX = Mathf.Abs(rotZ) > 90.0f;
    }
}

