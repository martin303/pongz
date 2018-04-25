using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerObject : NetworkBehaviour
{

    public GameObject playerPrefab;
    public Transform spawnPos1;
    public Transform spawnPos2;
    GameObject playerObject;

    private void Start()
    {
        if (isServer)
        {
            SpawnPlayer();
        }
    }

    void SpawnPlayer()
    {
        Debug.Log("CmdSpawnPlayer" + NetworkServer.connections.Count);
        playerObject = Instantiate(playerPrefab);
        if (NetworkServer.connections.Count == 1)
        {
            playerObject.transform.position = spawnPos1.position;
        }
        else
        {
            playerObject.transform.position = spawnPos2.position;
        }
        NetworkServer.SpawnWithClientAuthority(playerObject, connectionToClient);

    }
}
