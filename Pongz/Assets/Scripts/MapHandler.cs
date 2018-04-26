using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MapHandler : NetworkBehaviour {
    private int playerCount = 0;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnPlayerConnected(NetworkPlayer player)
    {
        Debug.Log("Player Connected");
        Vector2[] mapPoints = GetComponent<EdgeCollider2D>().points;
        Debug.Log(mapPoints.Length);
        for (int i = 0; i < mapPoints.Length; i++)
        {
            Debug.Log(mapPoints[i]);
        }
        //Debug.Log("Player " + playerCount++ + " connected from " + player.ipAddress + ":" + player.port);
    }
}
