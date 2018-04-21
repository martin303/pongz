using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bouncy_ball : MonoBehaviour
{
    //float horizontal;
    //float vertical;
    //float speed;

    //private void start()
    //{
    //    speed = 1;
    //}


    //update is called once per frame
    //void fixedupdate()
    //{
    //    horizontal = input.getaxis("horizontal");
    //    vertical = input.getaxis("vertical");


    //    check should cause sliding.
    //    if (horizontal != 0 || vertical != 0)
    //    {
    //        vector2 movement = new vector2(horizontal, vertical) * speed;
    //        getcomponent<transform>().position = new vector3(movement.x, movement.y, transform.position.z);
    //    }
    //}

    public Text textScore;
    public Text textScore2;
    public int playerOneScore;
    public int playerTwoScore;

    float thrust = 500;
    private Rigidbody2D rb;


    void Start()
    {
        UpdatePlayerOneScore();
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * thrust);
        rb.AddForce(transform.right * thrust);
        // Debug.Log("StartHAHAHAA");
        playerOneScore = 0;

    }
    
    void FixedUpdate()
    {
    }
    void Update()
    {
        //check if x speed is to low and double
       
        if (rb.velocity.x <= 4 && rb.velocity.x >= -4)
        {
            Debug.Log("OLD x speed:" + rb.velocity.x);
            rb.velocity = new Vector2(rb.velocity.x*2, rb.velocity.y);
            Debug.Log("NEW x Speed: " + rb.velocity.x);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");

    }


    void OnCollisionEnter2D(Collision2D col)
    {
        //Change to check if collision occurs with edge on right/left side.
        if (transform.position.x > 7) {
      //      Debug.Log("X: 12 hit");
            playerOneScore++;
            UpdatePlayerOneScore();
            Debug.Log(playerOneScore);
        }

        if (transform.position.x < -7)
        {
            //      Debug.Log("X: 12 hit");
            playerTwoScore++;
            UpdatePlayerTwoScore();
            Debug.Log(playerTwoScore);
        }

        //    Debug.Log("OnCollish");
        if (col.gameObject.name == "OuterSquare")
        {
     //       Debug.Log("OuterSwwuar");
        }
    }

    private void UpdatePlayerTwoScore()
    {

        textScore2.text = "Score: " + playerTwoScore.ToString();
    }

    void UpdatePlayerOneScore()
    {
        textScore.text = "Score: " + playerOneScore.ToString();
    }
}

