using UnityEngine;
using UnityEngine.UIElements;

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
                RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 50f, (1 << LayerMask.NameToLayer("map")) | target);
                
                if (hit.collider != null && target == (target | (1 << hit.collider.gameObject.layer)))
                {
                    CallMoveEvent(Vector2.zero);
                    IsAttacking = true;
                }
                else
                {
                    CallMoveEvent(direction);
                }
            }
            else
            {
                CallMoveEvent(direction);
            }
        }
        else
        {
            CallMoveEvent(direction);
        }
        Rotate(direction);
    }
}
