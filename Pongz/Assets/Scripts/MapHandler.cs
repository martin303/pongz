using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MapHandler : NetworkBehaviour {
    private int playerCount = 0;

    private void Start()
    {
        if (isServer)
        {
            ScaleMapSizeToScreenResolution();
            Debug.Log("is server");
        }
        if (hasAuthority)
        {
            //ScaleMapSizeToScreenResolution();
            Debug.Log("hasAuthority");
        }
        if (!hasAuthority)
        {
            //ScaleMapSizeToScreenResolution();
            Debug.Log("Not hasAuthority");
        }
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

    private void ScaleMapSizeToScreenResolution()
    {
        transform.localScale = Vector3.one;
        float widthEdgeCollider = GetComponent<EdgeCollider2D>().bounds.size.x;
        float heightEdgeCollider = GetComponent<EdgeCollider2D>().bounds.size.y;
        float cameraHeight = Camera.main.orthographicSize * 2.0f;
        float cameraWidth = cameraHeight * Screen.width / Screen.height;
        transform.localScale = new Vector3(cameraWidth / widthEdgeCollider, cameraHeight / heightEdgeCollider, 1f);

    }
}
