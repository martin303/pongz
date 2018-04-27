using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MapHandler : NetworkBehaviour {
    private int playerCount = 0;

    void Start()
    {   // Use this for initialization
        //void Update () {
        //    EdgeCollider2D ec = GetComponent<EdgeCollider2D>();
        //    float height = 2f * Camera.main.orthographicSize;
        //    float width = height * Camera.main.aspect;
        //    float scalex = width;
        //    Debug.Log("widht: " + width);
        //    Debug.Log("height: " + height);
        //    // GetComponent<EdgeCollider2D>().bounds.size.x = width;
        //    float collideryScale = ec.bounds.size.y;
        //    float colliderxScale = ec.bounds.size.x;
        //    Debug.Log("collideryScale: " + collideryScale);
        //    Debug.Log("colliderxScale: " + colliderxScale);
        //    ec.transform.localScale  = new Vector3(scalex, height, 0);

        //    // new Vector3(camera.orthographicSize * 2 * camera.aspect, camera.orthographicSize * 2);

        //}
    }
}