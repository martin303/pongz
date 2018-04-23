using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Bouncy_ball : NetworkBehaviour
{
    float thrust = 500;
    private Rigidbody2D rb;
    AudioSource audio;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * thrust);
        rb.AddForce(transform.right * thrust);
    }


    void Update()
    {
        //check if x speed is to low and double

        if (rb.velocity.x <= 4 && rb.velocity.x >= -4)
        {
            rb.velocity = new Vector2(rb.velocity.x * 2, rb.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "PlayerOne" || collision.gameObject.name == "PlayerTwo")
        {
            audio = collision.gameObject.GetComponent<AudioSource>();
            audio.Play();
        }
    }

}

