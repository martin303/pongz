using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class OnPlayerConnect : NetworkBehaviour
{
    public GameObject ballPrefab;
    public GameObject scoreBoardPrefab;
    public GameObject playerPrefab;
    public Transform spawnPos1;
    public Transform spawnPos2;
    GameObject Player;
    GameObject Ball;
    GameObject ScoreBoard;

    private void Start()
    {
        if (isServer)
        {
            SpawnPlayer();
            if (!GameObject.Find("Ball(Clone)"))
            {
                SpawnBall();
            }
        }
    }
    void SpawnPlayer()
    {
        Player = Instantiate(playerPrefab);
        
        if (GameObject.FindGameObjectsWithTag("Player").Length == 1)
        {
            Player.transform.position = spawnPos1.position;
        }
        else 
        {
            Player.transform.position = spawnPos2.position;
        }
        NetworkServer.SpawnWithClientAuthority(Player, connectionToClient);
    }
    void SpawnBall()
    {
        Ball = Instantiate(ballPrefab);
        Ball.transform.position = new Vector3(0, 0, 10);
        NetworkServer.Spawn(Ball);
    }
}
