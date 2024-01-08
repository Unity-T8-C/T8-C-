using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBomb : MonoBehaviour
{
    private Movement2D movement2D;
    private Explosion explosion;
    [SerializeField]
    private KeyCode keyCodeBoom = KeyCode.Z;

    public void Awake()
    {
        movement2D = GetComponent<Movement2D>();
        explosion = GetComponent<Explosion>();       
    }

    public void Update()
    {
        if (Input.GetKeyDown(keyCodeBoom))
        {
            explosion.StartBoom();
        }
    }
}
