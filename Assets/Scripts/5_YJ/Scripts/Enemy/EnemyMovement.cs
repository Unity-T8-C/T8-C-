using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private EnemyController Controller;

    private Vector2 movementDirection = Vector2.zero;
    private Rigidbody2D _rigidbody2D;
    private EnemyStatsHandler stats;

    private void Awake()
    {
        Controller = GetComponent<EnemyController>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        stats = GetComponent<EnemyStatsHandler>();
    }

    private void Start()
    {
        Controller.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        ApplyMovement(movementDirection);
    }

    private void Move(Vector2 direction)
    {
        movementDirection = direction;
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * stats.CurrentStats.moveSpeed;
        _rigidbody2D.velocity = direction;
    }
}