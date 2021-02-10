using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public float speed = 5;
    public float maxSpeed;
    public float HP;
    public float MaxTime;
    public float jumpForce;
    public float coolTime;
    public float recastTimer;


    public bool isStart = false ;
    public bool isJump = false;
    public bool isGround = true;
    public bool isSliding = false;
    public bool isDamage = false;
    public bool isOver = false;

    private const int MAX_JUMP_COUNT = 2;
    private int jumpCount = 0;
    private float MaxHP;

    private Rigidbody2D rb2d;
    private Animator anim;
    private CapsuleCollider2D caco;

    private float velx;
    private float vely;


    // Start is called before the first frame update
    void Start()
    {
        this.rb2d = GetComponent<Rigidbody2D>();
        this.anim = GetComponent<Animator>();
        this.caco = GetComponent<CapsuleCollider2D>();
        MaxHP = HP;
    }

    // Update is called once per frame
    void Update()
    {
        SetKey();
        SetDamage();
        SetOver();
        SetAnim();
        SetSpeed();
    }

    private void SetAnim()
    {
        anim.SetBool("isOver",isOver);
        anim.SetBool("isStart", isStart);
        anim.SetBool("isJump", isJump);
        anim.SetBool("isGround", isGround);
        anim.SetBool("isSliding",isSliding);
        anim.SetBool("isDamage",isDamage);
    }

    private void SetKey() 
    {
        if (jumpCount < MAX_JUMP_COUNT && Input.GetKeyDown(KeyCode.W))
        {
            isJump = true;
        }

        if (!isJump && isGround && Input.GetKey(KeyCode.S))
        {
            isSliding = true;
        }
        else
        {
            isSliding = false;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            isStart = true;
        }

    }

    private void SetDamage() 
    {
        if (isDamage) 
        {
            if (recastTimer > 0)
            {
                recastTimer -= Time.deltaTime / coolTime;
            }
            else 
            {
                isDamage = false;
            }
        }

        if(isStart)
            HP -= MaxHP * Time.deltaTime / MaxTime;
    }

    private void SetOver() 
    {
        if (HP < 0) 
        {
            HP = 0;
        }
        if (HP == 0) 
        {
            isOver = true;
            isStart = false;
        }
    
    
    }

    private void SetSpeed() 
    {
        velx = rb2d.velocity.x;
        vely = rb2d.velocity.y;

        if (velx > maxSpeed)
            rb2d.velocity = new Vector2(maxSpeed, vely);
    }

    private void FixedUpdate()
    {
        if(isStart)
            Run();
        if (!isStart)
            rb2d.velocity = new Vector2(0,0);

        if (isStart)
        {
            if (isJump)
                Jump();

            if (isSliding)
                Sliding();
            else
                NonSliding();
        }
    }

    private void Run() 
    {
        rb2d.AddForce(Vector2.right * speed);

    }

    private void Jump()
    {
        
        rb2d.velocity = new Vector2(velx ,0);

        rb2d.AddForce(Vector2.up * jumpForce);

        jumpCount++;

        isJump = false;

        isGround = false;
    
    }

    private void Sliding() 
    {
        caco.size = new Vector2(1,1);
        caco.offset = new Vector2(0,-1);
    }

    private void NonSliding() 
    {
        caco.size = new Vector2(1,3);
        caco.offset = new Vector2(0,0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
            jumpCount = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D col)//is Triggr on
    {
        if (!isDamage)
        {
            if (col.tag == "Block")
            {
                Damage();   
            }
        }
    }

    private void Damage() 
    {
        isDamage = true;
        recastTimer = 1;
        HP -= 30;
    }
}
