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

    public override void OnStartServer()
    {
        Debug.Log("ServerSTART");
    }
    private void Start()
    {
        if (isServer)
        {
            SpawnPlayer();
            if (!GameObject.Find("Ball(Clone)"))
            {
                SpawnBall();
            }
            //GameObject networking = GameObject.Find("Networking");
            //networking.GetComponent<NetworkManager>().ServerChangeScene("Offline");
        }
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
