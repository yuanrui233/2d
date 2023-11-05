using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UIElements;

public class NewBehaviourScript : MonoBehaviour
{

    public float speed;
    public bool vertical;
    private Rigidbody2D rigidbody2d;

    private int direction = 1;

    public float changerTime = 1.2f;//改变时间间隔常量

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        timer = changerTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            direction = -direction;
            timer = changerTime;
        }
    }

    private void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        if (vertical)
        {
            position.y += speed * Time.fixedDeltaTime*direction;
        }
        else
        {
            position.x += speed * Time.fixedDeltaTime*direction;
        }
        rigidbody2d.MovePosition(position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        RubyController rubyController = collision.gameObject.GetComponent<RubyController>();
        if (rubyController != null)
        {
            rubyController.ChangeHealth(-1);
        }
    }
}
