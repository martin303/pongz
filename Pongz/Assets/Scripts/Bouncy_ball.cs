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

    [SyncVar]
    Vector2 Velocity;
    [SyncVar]
    Vector3 Pos;
    Vector3 SeverRefPos;

    private void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (hasAuthority)
        {
            Debug.Log("hasAuthority updating ball");
            rb.AddForce(transform.up * thrust);
            rb.AddForce(transform.right * thrust);
        }
        if(!hasAuthority)
        {
            Debug.Log("!hasAuthority updating ball");
            Debug.Log("Vel before " + rb.velocity);
            rb.AddForce(transform.up * thrust);
            rb.AddForce(transform.right * thrust);
            Debug.Log("Vel after " + rb.velocity);
        }
        if (isServer)
        {
            Debug.Log("isServer updating ball");
            rb.AddForce(transform.up * thrust);
            rb.AddForce(transform.right * thrust);
        }
    }
    void Update()
    {
        if (isServer)
        {
            Debug.Log("Server updating ball");
            rb = GetComponent<Rigidbody2D>();
            if (rb.velocity.x <= 4 && rb.velocity.x >= -4)
            {
                Debug.Log("Vel before " + rb.velocity);
                rb.velocity = new Vector2(rb.velocity.x * 2, rb.velocity.y);
                Debug.Log("Vel after " + rb.velocity);
            }
            RpcUpdatePos(rb.position, rb.velocity);
        }
        if (hasAuthority)
        {
            Debug.Log("Clien with authority updateing bouncy_ball");
            rb = GetComponent<Rigidbody2D>();
            if (rb.velocity.x <= 4 && rb.velocity.x >= -4)
            {
                Debug.Log("Vel before " + rb.velocity);
                rb.velocity = new Vector2(rb.velocity.x * 2, rb.velocity.y);
                Debug.Log("Vel after " + rb.velocity);
            }
            CmdUpdatePos(rb.position, rb.velocity);
        }
        else if (!hasAuthority && !isServer)
        {
            Debug.Log("Client without authority updating ball");
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = Velocity;
            rb.position = Vector3.SmoothDamp(rb.position, Pos, ref SeverRefPos, 0.25f);
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
        if (collision.gameObject.name == "PlayerOne(Clone)")
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
        }
    }

    [Command]
    void CmdUpdatePos(Vector3 pos, Vector3 velocity)
    {
        Debug.Log("CMDUpdatepos ball");
        Pos = pos;
        Velocity = velocity;
    }

    [ClientRpc]
    void RpcUpdatePos(Vector3 pos, Vector3 velocity)
    {
        Debug.Log("RPCUpdatepos ball");
        Pos = pos;
        Velocity = velocity;
    }




}

