﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour {

    void Update()
    {
        var x = Input.GetAxis("Horizontal") * 0.1f;
        var z = Input.GetAxis("Vertical") * 0.1f;

        transform.Translate(x, 0, z);
    }
}
