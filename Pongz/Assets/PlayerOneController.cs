using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerOneController : NetworkBehaviour {
    public float speed = 0F;
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        float translation = Input.GetAxis("Vertical") * speed;
        translation *= Time.deltaTime;
        transform.Translate(0, translation, 0);
    }
}
