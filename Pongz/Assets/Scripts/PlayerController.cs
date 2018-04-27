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

    void Update()
    {
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
        //Get player input and move player
        float movement = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(0, movement, 0);

        //Update the server with new position
        CmdUpdatePosition(transform.position);
    }

    [Command]
    void CmdUpdatePosition(Vector3 newPosition)
    {
        serverPosition = newPosition;
    }
}
