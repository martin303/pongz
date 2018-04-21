using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoreboard : MonoBehaviour {

    
    public Collider2D ball;
    public Collider2D leftSide;
    public Collider2D rigtSide;
    int playerOneScore;
    int playerTwoScore;
    private void Start()
    {
        playerOneScore = 0;
        playerTwoScore = 0;
    }
    // Update is called once per frame
    void Update () {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }


    void OnCollisionEnter2D(Collision2D col)
    {



        //Change to check if collision occurs with edge on right/left side.
        //if (transform.position.x > 7)
        //{
        //    //      Debug.Log("X: 12 hit");
        //    playerOneScore++;
        //    UpdatePlayerScore(playerOneScore);
        //    Debug.Log(playerOneScore);
        //}

        //if (transform.position.x < -7)
        //{
        //    //      Debug.Log("X: 12 hit");
        //    playerTwoScore++;
        //    UpdatePlayerScore(playerTwoScore);
        //    Debug.Log(playerTwoScore);
        //}
    }

}
