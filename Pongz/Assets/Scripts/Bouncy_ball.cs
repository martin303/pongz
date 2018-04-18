using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    float thrust = 500;
    private Rigidbody2D rb;
    private int playerOneScore;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * thrust);
        rb.AddForce(transform.right * thrust);
       // Debug.Log("StartHAHAHAA");


    }

    void FixedUpdate()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
    }


    void OnCollisionEnter2D(Collision2D col)
    {
    //    if (col.transform.position.x >= 0 && col.transform.posit) {
        if (transform.position.x > 10) {
            Debug.Log("X: 12 hit");
            playerOneScore++;
        }

    //    Debug.Log("OnCollish");
        if (col.gameObject.name == "OuterSquare")
        {
     //       Debug.Log("OuterSwwuar");
        }
    }
}

