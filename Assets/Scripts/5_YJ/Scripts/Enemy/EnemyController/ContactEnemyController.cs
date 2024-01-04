using UnityEngine;

public class ContactEnemyController : EnemyController
{ 
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
        // player �� �ε����� �� ��� ó�� �� ������ ( HP )
        if (collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }

    private void HpChange()
    {
        EnemySO enemySO = Stats.CurrentStats.enemySO;
        // bool damage = ( ĳ���Ϳ� �浹 ���� �� ĳ������ ���ݷ� ��ŭ -)
    }

    private void DestroyProjectile()
    {
        gameObject.SetActive(false);
    }
}
