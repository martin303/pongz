using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerOneController : NetworkBehaviour {


    public float speed = 10f;
    void Update()
    {
        if (!hasAuthority)
        {
            return;
        }
        var y = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        transform.Translate(0, y, 0);


    }
}
