using UnityEngine;

public class BossEnemyController : EnemyController
{
    [SerializeField] private float shootRange;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        float distance = DistanceToTarget();
        Vector2 direction = DirectionToTarget();

        IsAttacking = false;
        if (distance <= shootRange)
        {
            int target = Stats.CurrentStats.enemySO.target;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 50f, (1 << LayerMask.NameToLayer("map")) | target);

            if (hit.collider != null && target == (target | (1 << hit.collider.gameObject.layer)))
            {
                CallLookEvent(direction);
                IsAttacking = true;
            }
            else
            {
                CallLookEvent(direction);
            }
        }
        else
        {
            CallLookEvent(direction);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);

            currentHP -= 30;
            Debug.Log($"{currentHP}");
        }

        if(currentHP <= 0)
        {
            Destroy(gameObject);
            Time.timeScale = 0.0f;
            GameManager.Instance.PlayerWin();
        }
    }
}
