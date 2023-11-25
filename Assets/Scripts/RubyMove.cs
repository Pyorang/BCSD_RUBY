using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyMove : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;

    public float prepareBullet;

    float RunMultiple;
    float h;
    float v;
    bool isHorizonMove;
    bool bulletReady;


    [SerializeField]
    private float RubySpeed;
    [SerializeField]
    private GameObject Bullet;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        bulletReady = true;
    }

    void Update()
    {
        //Move Value
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        //Check Button Down & Up
        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");

        //Check Run
        if(Input.GetButton("Fire3")) RunMultiple = 1.5f;
        else RunMultiple = 1;

        //Check Horizontal Move
        if (hDown)
            isHorizonMove = true;
        else if (vDown)
            isHorizonMove = false;
        else if (hUp || vUp)
        {
            isHorizonMove = h != 0;
        }

        //Animation Parameter Set
        if(Time.timeScale != 0)
        {
            if (anim.GetInteger("hAxisRaw") != h)
            {
                anim.SetBool("isChange", true);
                anim.SetInteger("hAxisRaw", (int)h);
            }

            else if (anim.GetInteger("vAxisRaw") != v)
            {
                anim.SetBool("isChange", true);
                anim.SetInteger("vAxisRaw", (int)v);
            }

            else
                anim.SetBool("isChange", false);
        }

        //Throw Bullet
        if (Input.GetButtonDown("Jump") && Time.timeScale != 0)
        {
            if(bulletReady)
            {
                Instantiate(Bullet, rigid.position + new Vector2(0.4f, 0.5f), Quaternion.identity);
                anim.SetBool("isAttack", true);
                anim.SetBool("isChange", true);
                Invoke("attackAnim", 0.1f);
                Invoke("PrepareBullet", prepareBullet);
            }
            bulletReady = false;
        }
    }

    void FixedUpdate()
    {
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * RubySpeed * RunMultiple;
    }

    void PrepareBullet()
    {
        bulletReady = true;
    }

    void attackAnim()
    {
        anim.SetBool("isAttack", false);
    }
}
