using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;



public class Network : MonoBehaviour {

	// Use this for initialization
	void Start () {
        NetworkManager manager = GetComponent<NetworkManager>();
        manager.StartServer();
        manager.StartClient();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
