using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float speed;
    public float power;
    public float maxShotDelay;
    public float curShotDelay;

    public bool isTouchTop;
    public bool isTouchBottom;
    public bool isTouchRight;
    public bool isTouchLeft;

    public GameObject bulletObjA;
    public GameObject bulletObjB;

    Animator anim;
   
    
    void Start()
    {
        
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();    
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
        Reload();
    }


   void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if ((isTouchRight && h == 1) || (isTouchLeft && h == -1))
        {
            h = 0;
        }


        float v = Input.GetAxisRaw("Vertical");
        if ((isTouchTop && v == 1) || (isTouchBottom && v == -1))
        {
            v = 0;
        }

        Vector3 PlayerPos = transform.position;
        Vector3 MovePos = new Vector3(h, v, 0).normalized * speed * Time.deltaTime;

        transform.position = PlayerPos + MovePos;

        if (Input.GetButtonDown("Horizontal") || Input.GetButtonUp("Horizontal"))
            {
            anim.SetInteger("Input", (int)h);
        }
    }

    void Fire()
    {
        if (!Input.GetButton("Fire1"))
            return; //이제 눌러야지 쏠수 있음!!

        if (curShotDelay < maxShotDelay)
            return;
        
        switch(power)
        {
            case 1:
                GameObject bullet = Instantiate(bulletObjA, transform.position, transform.rotation);
                Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                rigid.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                break;
            case 2:
                GameObject bulletR = Instantiate(bulletObjA, transform.position+Vector3.right*0.1f, transform.rotation);
                GameObject bulletL = Instantiate(bulletObjA, transform.position + Vector3.left * 0.1f, transform.rotation);
                Rigidbody2D rigidR = bulletR.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidL = bulletL.GetComponent<Rigidbody2D>();
                rigidR.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidL.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                break;
            case 3:
                GameObject bulletRR = Instantiate(bulletObjA, transform.position + Vector3.right * 0.2f, transform.rotation);
                GameObject bulletCC = Instantiate(bulletObjB, transform.position, transform.rotation);
                GameObject bulletLL = Instantiate(bulletObjA, transform.position + Vector3.left * 0.2f, transform.rotation);
                Rigidbody2D rigidRR = bulletRR.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidCC = bulletCC.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidLL = bulletLL.GetComponent<Rigidbody2D>();
                rigidRR.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidCC.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                rigidLL.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                break;
        }
        

        curShotDelay = 0;
    }

    void Reload()
    {
        curShotDelay += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = true;
                    break;

                case "Bottom":
                    isTouchBottom = true;
                    break;

                case "Right":
                    isTouchRight = true;
                    break;

                case "Left":
                    isTouchLeft = true;
                    break;
            }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = false;
                    break;

                case "Bottom":
                    isTouchBottom = false;
                    break;

                case "Right":
                    isTouchRight = false;
                    break;

                case "Left":
                    isTouchLeft = false;
                    break;
            }
    }
}
