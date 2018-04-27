using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MapHandler : NetworkBehaviour
{
    EdgeCollider2D map;
    public List<Vector2> hexagonPoints = new List<Vector2>();

    void Start()
    {
        map = GetComponent<EdgeCollider2D>();
        float mapWidth = map.bounds.size.x;
        float mapHeight = map.bounds.size.y;
        float cameraHeight = Camera.main.orthographicSize * 2.0f;
        float cameraWidth = cameraHeight * AspectUtility.screenWidth / AspectUtility.screenHeight;

        if (NetworkServer.connections.Count <= 2)
        {
            transform.localScale = Vector3.one;
            transform.localScale = new Vector3(cameraWidth / mapWidth, cameraHeight / mapHeight, 1f);
        }
        else if (NetworkServer.connections.Count > 2 && NetworkServer.connections.Count >= 4)
        {
            hexagonPoints.Add(new Vector2(cameraWidth/4, -cameraHeight/2));
            hexagonPoints.Add(new Vector2(cameraWidth/2, 0));
            hexagonPoints.Add(new Vector2(cameraWidth/4, cameraHeight/2));
            hexagonPoints.Add(new Vector2(-cameraWidth/4, cameraHeight / 2));
            hexagonPoints.Add(new Vector2(-cameraWidth/2, 0));
            hexagonPoints.Add(new Vector2(-cameraWidth/4, -cameraHeight/2));
            hexagonPoints.Add(new Vector2(cameraWidth / 4, -cameraHeight / 2));

            map.points = hexagonPoints.ToArray();
        }
    }
}

