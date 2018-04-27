using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

    public float speed = 10f;

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
            AuthorityUpdate();
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
