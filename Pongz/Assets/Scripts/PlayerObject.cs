using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerObject : NetworkBehaviour
{
    public GameObject ballPrefab;
    public GameObject playerPrefab;
    public Transform spawnPos1;
    public Transform spawnPos2;
    GameObject Object;

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
        Debug.Log("CmdSpawnPlayer" + NetworkServer.connections.Count);
        Object = Instantiate(playerPrefab);
        if (NetworkServer.connections.Count == 1)
        {
            Object.transform.position = spawnPos1.position;
        }
        else
        {
            Object.transform.position = spawnPos2.position;
        }
        NetworkServer.SpawnWithClientAuthority(Object, connectionToClient);
    }

    void SpawnBall()
    {
        Debug.Log("CmdSpawnBall" + NetworkServer.connections.Count);
        Object = Instantiate(ballPrefab);
            Object.transform.position = new Vector3(0, 0, 10);
            NetworkServer.SpawnWithClientAuthority(Object, connectionToServer);
    }

}
