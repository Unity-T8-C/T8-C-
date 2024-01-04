using System;
using UnityEngine;

public class EnemyController : TopDownEnemyController
{
    private GameManager gameManager;

    [SerializeField] protected SpriteRenderer mainSpriteRenderer;

    protected Transform target { get; private set; }

    [SerializeField][Range(0.0f, 100.0f)] protected float followRange;

    protected virtual void Start()
    { 
        gameManager = GameManager.Instance;
        target = gameManager.Player.transform;
    }

    protected override void Awake()
    {
        base.Awake();
    }

    protected virtual void FixedUpdate()
    {
        
    }

    protected float DistanceToTarget() // 표적까지의 거리
    {
        return Vector3.Distance(transform.position, target.position);
    }

    protected Vector2 DirectionToTarget() // 표적 방향
    {
        return (target.position - transform.position).normalized;
    }

    protected void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        mainSpriteRenderer.flipX = Mathf.Abs(rotZ) > 90.0f;
    }
}

