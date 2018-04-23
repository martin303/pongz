using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerObject : NetworkBehaviour
{

    public GameObject playerPrefab;
    public Transform spawnPos1;
    public Transform spawnPos2;

    private void Start()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        CmdSpawnPlayer();
    }

    [Command]
    void CmdSpawnPlayer()
    {
        Debug.Log("CmdSpawnPlayer" + NetworkServer.connections.Count);
        GameObject go = Instantiate(playerPrefab);
        if (NetworkServer.connections.Count == 1)
        {
            go.transform.position = spawnPos1.position;
            NetworkServer.SpawnWithClientAuthority(go, connectionToClient);
        }
        else
        {
            go.transform.position = spawnPos2.position;
            NetworkServer.SpawnWithClientAuthority(go, connectionToClient);
        }
    }
}
