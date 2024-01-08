using System;
using UnityEngine;

public class TopDownEnemyController : MonoBehaviour
{

    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action<EnemySO> OnAttackEvent;

    protected EnemyStatsHandler Stats { get; private set; }
    protected CharacterMove characterStats;

    private float _timeSinceLastAttack = float.MaxValue;
    protected bool IsAttacking { get; set; }

    protected virtual void Awake()
    {
        Stats = GetComponent<EnemyStatsHandler>();
        characterStats = GetComponent<CharacterMove>();
    }

    protected virtual void Update()
    {
        AttackDelay();
    }

    private void AttackDelay()
    {
        if (Stats.CurrentStats.enemySO == null)
            return;

        if (_timeSinceLastAttack <= Stats.CurrentStats.enemySO.atkDelay)
        {
            _timeSinceLastAttack += Time.deltaTime;
        }

        if (IsAttacking && _timeSinceLastAttack > Stats.CurrentStats.enemySO.atkDelay)
        {
            _timeSinceLastAttack = 0;
            CallAttackEvent(Stats.CurrentStats.enemySO);
        }
    }

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }

    public void CallAttackEvent(EnemySO enemySO)
    {
        OnAttackEvent?.Invoke(enemySO);
    }
}
