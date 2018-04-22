using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trigger_left_side : MonoBehaviour {

    int playerOneScore = 0;
    public Text playerOneScoreText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerOneScore++;
        playerOneScoreText.text = playerOneScore.ToString();
    }
}
