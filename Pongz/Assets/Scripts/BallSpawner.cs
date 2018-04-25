using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BallSpawner : NetworkBehaviour
{


    public GameObject ballPrefab;
    public Transform ballSpawnPos;

    GameObject instance;


    private void Start()
    {
        
            Debug.LogError("Authority Spawning ball");

        CmdSpawnBall();
            

        
    }

   [Command]
   public void CmdSpawnBall()
    {
        instance = Instantiate(ballPrefab, ballSpawnPos);
        NetworkServer.Spawn(instance);
        Debug.LogError("Server Spawning ball complete");
    }
    
       
    
}
