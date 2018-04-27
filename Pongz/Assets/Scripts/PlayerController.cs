using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{

    public float speed = 10f;

    [SyncVar]
    Vector3 serverPosition;
    Vector3 serverPositionSmoothVelocity;

    void Start()
    {

    }
    void Update()
    {

        if (isServer)
        {
        }
        if (hasAuthority)
        {


            AuthorityUpdate();
            GameObject map = GameObject.Find("Map(Clone)");
            float widthToBeSeen = map.GetComponent<EdgeCollider2D>().bounds.size.x;
            Camera.main.orthographicSize = widthToBeSeen * Screen.height / Screen.width * 0.5f;

            //float height = Camera.main.orthographicSize / Camera.main.aspect;
            //Camera.main.aspect = 
            //float TARGET_WIDTH = 960.0f;
            //float TARGET_HEIGHT = 540.0f;
            //int PIXELS_TO_UNITS = 30; // 1:1 ratio of pixels to units

            //float desiredRatio = TARGET_WIDTH / TARGET_HEIGHT;
            //float currentRatio = (float)Screen.width / (float)Screen.height;

            //Debug.Log("DesiredRatio: " + desiredRatio);
            //Debug.Log("TargetWidth: " + map.GetComponent<EdgeCollider2D>().bounds.size.x);
            //Debug.Log("Width: " + Screen.width + " height: " + Screen.height);
            //Debug.Log("CurrentRatio:" + currentRatio);


            for (int i = 0; i < map.GetComponent<EdgeCollider2D>().points.Length-1; i++)
            {
                Debug.DrawLine(map.GetComponent<EdgeCollider2D>().points[i], map.GetComponent<EdgeCollider2D>().points[i+1], Color.red);
            }



            //if (currentRatio >= desiredRatio)
            //{
            //    // Our resolution has plenty of width, so we just need to use the height to determine the camera size
            //    Debug.Log("1");
            //    Camera.main.orthographicSize = TARGET_HEIGHT / 4 / PIXELS_TO_UNITS;
            //}
            //else
            //{
            //    Debug.Log("2");
            //    // Our camera needs to zoom out further than just fitting in the height of the image.
            //    // Determine how much bigger it needs to be, then apply that to our original algorithm.
            //    float differenceInSize = desiredRatio / currentRatio;
            //    Camera.main.orthographicSize = TARGET_HEIGHT / 4 / PIXELS_TO_UNITS * differenceInSize;
            //}
        }
        else
        {
            transform.position = Vector3.SmoothDamp(transform.position, serverPosition, ref serverPositionSmoothVelocity, 0.25f);
        }
    }

    void AuthorityUpdate()
    {
        // Listen for keyboard commands for movement
        float movement = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        // TODO: track movement left

        // We have authority, and we don't want any input lag -- so lets move ourselves.
        transform.Translate(0, movement, 0);

        // Do we manually tell the network where we moved?
        CmdUpdatePosition(transform.position);


    }

    [Command]
    void CmdUpdatePosition(Vector3 newPosition)
    {
        serverPosition = newPosition;
    }
}
