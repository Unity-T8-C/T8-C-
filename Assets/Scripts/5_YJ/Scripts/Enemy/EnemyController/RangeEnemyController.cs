using UnityEngine;

public class RangeEnemyController : EnemyController
{
    [SerializeField] private float shootRange = 10f;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        float distance = DistanceToTarget();
        Vector2 direction = DirectionToTarget();

        IsAttacking = false;
        if(distance <= followRange)
        {
            if(distance <= shootRange)
            {
                int target = Stats.CurrentStats.enemySO.target;
                RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 30f, (1 << LayerMask.NameToLayer("map")) | target);
                
                if (hit.collider != null && target == (target | (1 << hit.collider.gameObject.layer)))
                {
                    CallLookEvent(direction);
                    CallMoveEvent(Vector2.zero);
                    IsAttacking = true;
                }
                else
                {
                    CallLookEvent(direction);
                    CallMoveEvent(direction);
                }
            }
            else
            {
                CallLookEvent(direction);
                CallMoveEvent(direction);
            }
        }
        else
        {
            CallLookEvent(direction);
            CallMoveEvent(direction);
        }
        Rotate(direction);
    }
}
