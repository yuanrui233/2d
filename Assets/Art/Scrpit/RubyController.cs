using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rigidbody2d;
    //blod
    public int maxHealth = 5;
    private int currentHealth;
    //无敌
    public float timeInvincible = 0.1f; //无敌帧
    public bool isInvincible;
    public float invincibleTimer;

    public int Health
    {
        get { return currentHealth; }
    }

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }


    void Update()
    {
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer <= 0)
            {
                isInvincible = false;
            }
        }
    }

    private void FixedUpdate()
    {
        //专门写刚体移动，刚体函数每0.02s调用一次，fix也是0.02调用一次。
        //普通的update与刚体无法做到同时读取，会产生跳帧
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 position = transform.position;
        position.x += speed * horizontal * Time.fixedDeltaTime;
        position.y += speed * vertical * Time.fixedDeltaTime;
        //transform.position = position;
        rigidbody2d.MovePosition(position);
    }

//void 不会有返回值（无参无返，有参无返）
    public void ChangeHealth(int amout)
    {
        if (amout < 0)
        {
            if (isInvincible)
            {
                return;
            }

            isInvincible = true;
            invincibleTimer = timeInvincible;
        }

        currentHealth = Mathf.Clamp(currentHealth + amout, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}


