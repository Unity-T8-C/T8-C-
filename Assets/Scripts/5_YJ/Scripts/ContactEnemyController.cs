using UnityEngine;

public class ContactEnemyController : EnemyController
{
    private EnemyMovement movement;

    private bool targetCollding; // 충돌 확인

    protected override void Start()
    {
        base.Start();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        Vector2 direction = Vector2.zero;
        if(DistanceToTarget() < followRange)
        {
            direction = DirectionToTarget();
        }

        CallMoveEvent(direction);
        Rotate(direction);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.gameObject;

        if (!player)
        {
            return;
        }

        movement = player.GetComponent<EnemyMovement>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!player)
        {
            return;
        }

    }

    private void HpChange()
    {
        EnemySO enemySO = Stats.CurrentStats.enemySO;
        // bool damage = ( 캐릭터와 충돌 했을 때 캐릭터의 공격력 만큼 -)
    }
}
