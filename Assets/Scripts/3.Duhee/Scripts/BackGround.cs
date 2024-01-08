using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public Transform target;
    public float Background = 170f;
    public float movespeed = 3f;

    public Vector3 moveDirection = Vector3.down;
   

    void Update()
    {
        transform.position += moveDirection * movespeed * Time.deltaTime;

        if(transform.position.y <=-Background)
        {
            transform.position = target.position + Vector3.up * Background;
        }
    }
}
