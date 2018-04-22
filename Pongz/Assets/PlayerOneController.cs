using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerOneController : NetworkBehaviour {
    public GameObject ballPrefab;

    public float speed = 0F;
    float thrust = 500;

    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        float translation = Input.GetAxis("Vertical") * speed;
        translation *= Time.deltaTime;
        transform.Translate(0, translation, 0);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Command function is called from the client, but invoked on the server
            CmdSpawnBall();
        }
    }

    [Command]
    void CmdSpawnBall()
    {
        // This [Command] code is run on the server!

        // create the bullet object locally
        var ball = (GameObject)Instantiate(
             ballPrefab,
             new Vector2(0,0),
             Quaternion.identity);

        //ball.GetComponent<Rigidbody>().AddForce(transform.up * thrust);
        //ball.GetComponent<Rigidbody>().AddForce(transform.right * thrust);

        // spawn the bullet on the clients
        NetworkServer.Spawn(ball);

        // when the bullet is destroyed on the server it will automaticaly be destroyed on clients
       // Destroy(ball, 2.0f);
    }
}
