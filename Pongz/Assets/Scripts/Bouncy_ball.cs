using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Bouncy_ball : NetworkBehaviour
{
    float thrust = 100;
    private Rigidbody2D rb;
    private float constantSpeed;
    private Vector2 oldVelocity;
    private float imposs;


    [SyncVar]
    Vector2 Velocity;
    [SyncVar]
    Vector3 Pos;
    Vector3 SeverRefPos;

    private void Start()
    {
        constantSpeed = 10f;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (isServer)
        {
            rb.AddForce(transform.up * thrust);
            rb.AddForce(transform.right * thrust);
        }
    }
    void Update()
    {
        if (isServer)
        {
            rb = GetComponent<Rigidbody2D>();
            UpdateBallSpeed();
            RpcUpdatePos(rb.position, rb.velocity);
        }
        else
        {
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = Velocity;
            rb.position = Vector3.SmoothDamp(rb.position, Pos, ref SeverRefPos, 0.25f);
        }
    }

    void UpdateBallSpeed()
    {
        rb.velocity = rb.velocity.normalized * constantSpeed;
        if(rb.velocity.y == 0)
        {
            Debug.Log("Y == 0, update velocity");
            rb.velocity = new Vector2(rb.velocity.x ,oldVelocity.y);
        }
        if (rb.velocity.x == 0)
        {
            Debug.Log("X == 0, update velocity");
            rb.velocity = new Vector2(oldVelocity.x, rb.velocity.y);
        }
    }




    //void Update()
    //{
        //check if x speed is to low and double

        //if (rb.velocity.x <= 4 && rb.velocity.x >= -4)
        //{
        //    rb.velocity = new Vector2(rb.velocity.x * 2, rb.velocity.y);
        //}
        //if (!hasAuthority)
        //{
        //RpcUpdatePos(rb.position, rb.velocity);
        //}
        //CmdUpdatePos(rb.position, rb.velocity);
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        oldVelocity = collision.relativeVelocity;
        if (collision.gameObject.name == "Player(Clone)")
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
        }
    }

    [Command]
    void CmdUpdatePos(Vector3 pos, Vector3 velocity)
    {
        Pos = pos;
        Velocity = velocity;
    }

    [ClientRpc]
    void RpcUpdatePos(Vector3 pos, Vector3 velocity)
    {
        Pos = pos;
        Velocity = velocity;
    }




}

