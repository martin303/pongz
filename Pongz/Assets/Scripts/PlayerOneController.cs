using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerOneController : NetworkBehaviour {

    public GameObject Ball;
    public Transform BallSpawnPoint;
    public float speed = 10f;
    static public PlayerOneController LocalPlayerObject { get; protected set; }

    [SyncVar]
    Vector3 serverPosition;
    Vector3 serverPositionSmoothVelocity;

    void Update()
    {

        if (isServer)
        {
        }
        if (hasAuthority)
        {
            LocalPlayerObject = this;
            AuthorityUpdate();
        }
        else
        {
            transform.position = Vector3.SmoothDamp(transform.position, serverPosition, ref serverPositionSmoothVelocity, 0.25f);
        }

        //if (!hasAuthority)
        //{
        //    return;
        //}
        //var y = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        //transform.Translate(0, y, 0);


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

        //if (Input.GetKeyUp(KeyCode.Space) && NetworkServer.connections.Count <= 1)
        //{
        //    GameObject ball = Instantiate(Ball, BallSpawnPoint);
        //    NetworkServer.SpawnWithClientAuthority(ball,connectionToClient);
        //}
    }

    [Command]
    void CmdUpdatePosition(Vector3 newPosition)
    {
        // TODO: Check to make sure this move is totally legal,
        // both in term of landscape and movement remaining
        // and finally (and most importantly) the TURN PHASE
        // If an illegal move is spotted, do something like:
        //      RpcFixPosition( serverPosition )
        // and return
        serverPosition = newPosition;
    }
}
