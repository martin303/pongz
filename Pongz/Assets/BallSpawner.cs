using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BallSpawner : NetworkBehaviour
{


    public GameObject ballPrefab;
    GameObject instance;


    public override void OnStartServer()
    {
        instance = Instantiate(ballPrefab);
        NetworkServer.Spawn(instance);
    }
}
