using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trigger_right_side : MonoBehaviour {


    int playerTwoScore = 0;
    public Text playerTwoScoreText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerTwoScore++;
        playerTwoScoreText.text = playerTwoScore.ToString();
    }
}
