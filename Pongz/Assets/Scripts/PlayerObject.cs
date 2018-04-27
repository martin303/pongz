using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerObject : NetworkBehaviour
{
    public GameObject ballPrefab;
    public GameObject scoreBoardPrefab;
    public GameObject playerPrefab;
    public GameObject mapPrefab;
    public Transform spawnPos1;
    public Transform spawnPos2;
    GameObject Player;
    GameObject Map;
    GameObject Ball;
    GameObject ScoreBoard;


    private void Start()
    {
        if (isServer)
        {
            SpawnMap();
            SpawnScoreBoard();
            SpawnPlayer();
            if (!GameObject.Find("Ball(Clone)"))
            {
                SpawnBall();
            }
        }
    }

    private void SpawnScoreBoard()
    {
        ScoreBoard = Instantiate(scoreBoardPrefab);
        NetworkServer.Spawn(ScoreBoard);
    }

    private void SpawnMap()
    {
        Map = Instantiate(mapPrefab);
        NetworkServer.Spawn(Map);
    }

    void SpawnPlayer()
    {
        Player = Instantiate(playerPrefab);
        if (NetworkServer.connections.Count == 1)
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
