using UnityEngine;

public class ContactEnemyController : EnemyController
{
    private EnemyMovement movement;

    private bool targetCollding; // �浹 Ȯ��

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
        // bool damage = ( ĳ���Ϳ� �浹 ���� �� ĳ������ ���ݷ� ��ŭ -)
    }
}
