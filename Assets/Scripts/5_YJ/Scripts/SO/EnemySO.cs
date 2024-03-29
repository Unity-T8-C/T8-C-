using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemys/Enemy", order = 0)]
public class EnemySO : ScriptableObject
{
    [Header("Enemy Info")]

    public int hp;
    public int atk;
    public float atkDelay;
    public LayerMask target;

    [Header("Boss Info")]
    public int bossHp;
    public int bossAtk;
    public float bossAtkDelay;
    public bool isBoss;

}
