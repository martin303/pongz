using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreePlayerMap : MonoBehaviour {

    // Use this for initialization
    void Start ()
    {
        List<Vector2> hexagonPoints = new List<Vector2>();
        EdgeCollider2D map = GetComponent<EdgeCollider2D>();
        float cameraHeight = Camera.main.orthographicSize *2;
        float s = cameraHeight / 2;
        float r = Mathf.Sqrt(3)/2*s;

        hexagonPoints.Add(new Vector2(0, -s));
        hexagonPoints.Add(new Vector2(r, -s / 2));
        hexagonPoints.Add(new Vector2(r, s / 2));
        hexagonPoints.Add(new Vector2(0, s));
        hexagonPoints.Add(new Vector2(-r, s / 2));
        hexagonPoints.Add(new Vector2(-r, -s / 2));
        hexagonPoints.Add(new Vector2(0, -s));
        map.points = hexagonPoints.ToArray();

    }

    // Update is called once per frame
    void Update () {
		
	}
}
