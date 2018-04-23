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
        if (!hasAuthority)
        {
            RpcUpdatePos(rb.position, rb.velocity);
        }
        CmdUpdatePos(rb.position, rb.velocity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "PlayerOne" || collision.gameObject.name == "PlayerTwo")
        {
            audio = gameObject.GetComponent<AudioSource>();
            audio.Play();
        }
    }

    [Command]
    void CmdUpdatePos(Vector3 pos, Vector3 velocity)
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = (velocity);
        gameObject.transform.position = pos;
    }

    [ClientRpc]
    void RpcUpdatePos(Vector3 pos, Vector3 velocity)
    {
        if (!hasAuthority)
        {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = (velocity);
        gameObject.transform.position = pos;
        }   

    }




}

