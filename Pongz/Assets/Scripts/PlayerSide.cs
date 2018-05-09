using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerSide : NetworkBehaviour {
    [SyncVar(hook = "UpdateScoreP1")]
    int playerOneScore = 0;
    public Text playerOneScoreText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isServer)
        {
            return;
        }
        playerOneScore++;
        playerOneScoreText.text = playerOneScore.ToString();
    }
    public void UpdateScoreP1(int score)
    {
        playerOneScoreText.text = score.ToString();
    }
}
