using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Trigger_right_side : NetworkBehaviour {

    [SyncVar(hook = "UpdateScoreP2")]
    int playerTwoScore = 0;
    public Text playerTwoScoreText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isServer)
        {
            return;
        }
        playerTwoScore++;
        playerTwoScoreText.text = playerTwoScore.ToString();
    }
    public void UpdateScoreP2(int score)
    {
        playerTwoScoreText.text = score.ToString();
    }
}
