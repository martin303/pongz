using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BallSpawner : NetworkBehaviour
{


    public GameObject ballPrefab;
    public Transform ballSpawnPos;

    public override void OnStartServer()
    {
        GameObject instance = Instantiate(ballPrefab, ballSpawnPos);
        NetworkServer.Spawn(instance);
    }



}
