using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreePlayerMap : MonoBehaviour
{
    public GameObject playerSidePrefab;

    // Use this for initialization
    void Start ()
    {
        //   BuildMap();
        GenerateMapFromCirlce(4);

    }

    private void GenerateMapFromCirlce(int sides)
    {
        Vector3 center = transform.position;
        for (int i = 0; i < sides; i++)
        {
            int a = i * (360/sides);
            Vector3 pos = RandomCircle(center, Camera.main.orthographicSize, a);
            GameObject go = Instantiate(playerSidePrefab, pos, Quaternion.identity);

            go.transform.parent = gameObject.transform;
            go.transform.localScale = new Vector3(1f, 0.2f);
            go.transform.eulerAngles = new Vector3(
                go.transform.eulerAngles.x,
                go.transform.eulerAngles.y,
                go.transform.eulerAngles.z + a *-1
            );
            go.AddComponent<BoxCollider2D>();
            go.name = "PlayeSide" + i;
        }
    }
    
    Vector3 RandomCircle(Vector3 center, float radius, int a)
    {
        float ang = a;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }
    private void BuildMap()
    {
        List<Vector2> hexagonPoints = new List<Vector2>();
        float cameraHeight = Camera.main.orthographicSize * 2;
        float s = cameraHeight / 2;
        float r = Mathf.Sqrt(3) / 2 * s;

        hexagonPoints.Add(new Vector2(0, -s));
        hexagonPoints.Add(new Vector2(r, -s / 2));
        hexagonPoints.Add(new Vector2(r, s / 2));
        hexagonPoints.Add(new Vector2(0, s));
        hexagonPoints.Add(new Vector2(-r, s / 2));
        hexagonPoints.Add(new Vector2(-r, -s / 2));
        hexagonPoints.Add(new Vector2(0, -s));

        EdgeCollider2D map = GetComponent<EdgeCollider2D>();
        map.points = hexagonPoints.ToArray();
    }
}
