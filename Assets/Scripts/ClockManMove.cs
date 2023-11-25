using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockManMove : MonoBehaviour
{
    bool clockbulletReady;

    RectTransform rectTransform;
    Rigidbody2D rigid;
    Animator animator;

    [SerializeField]
    private float ClockManSpeed;
    [SerializeField]
    private GameObject clockManBullet;
    [SerializeField]
    private GameObject sniperRader;
    [SerializeField]
    private float prepareClockBullet;
    [SerializeField]
    private GameObject Ruby;

    void Awake()
    {
        sniperRader.SetActive(false);
        Ruby = GameObject.FindWithTag("Player");
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rectTransform = clockManBullet.GetComponent<RectTransform>();
        animator.SetBool("isPreparing", true);
        clockbulletReady = true;
        StartMove();
        Invoke("StopMove", Random.Range(1.5f, 5f));
    }

    void Update()
    {
        if(clockbulletReady && rigid.velocity == Vector2.zero)
        {
            sniperRader.SetActive (false);
            ShootBullet();
            Invoke("SetRaderOn", prepareClockBullet/2);
            Invoke("PrepareBullet", prepareClockBullet);
        }
        if(rigid.velocity == Vector2.zero) clockbulletReady = false;
    }

    void StartMove()
    {
        rigid.velocity = Vector2.left * ClockManSpeed;
    }

    void StopMove()
    {
        rigid.velocity = Vector2.zero;
        animator.SetBool("isPreparing", false);
        SetRaderOn();
    }

    void ShootBullet()
    {
        Instantiate(clockManBullet, rigid.position + new Vector2(0.4f, 0.5f), Quaternion.identity);
        clockManBullet.transform.eulerAngles = new Vector3(0, 0, GetAngle(Ruby.transform.position, gameObject.transform.position));
    }

    void SetRaderOn()
    {
        sniperRader.SetActive(true);
    }

    void PrepareBullet()
    {
        clockbulletReady = true;
    }

    float GetAngle(Vector2 start, Vector2 end)
    {
        Vector2 v2 = end - start;
        return Mathf.Atan2(v2.y, v2.x) * Mathf.Rad2Deg;
    }
}
