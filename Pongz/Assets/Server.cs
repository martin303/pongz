using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Server : NetworkBehaviour {
    public GameObject mapPrefab;
    GameObject Map;

    public override void OnStartServer()
    {
        Debug.Log("Server: On start server");
        SpawnMap();
    }

    private void SpawnMap()
    {
        Map = Instantiate(mapPrefab);
        NetworkServer.Spawn(Map);
    }
}
