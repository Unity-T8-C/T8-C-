using UnityEngine;

public class Enemy : MonoBehaviour
{
    [field : Header("EnemySO")]
    [field : SerializeField] public EnemySO Data {  get; private set; }

    public Rigidbody2D Rigidbody { get; private set; }
    public EnemyController Controller { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Controller = GetComponent<EnemyController>();
    }
}
