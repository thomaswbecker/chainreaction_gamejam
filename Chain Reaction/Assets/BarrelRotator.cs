﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelRotator : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        transform.Rotate(0, x, 0, Space.World);
        if (Input.GetKey(KeyCode.Space))
        {
            GetComponent<IExplodeable>().Explode(Vector3.zero, additionalDelay: GameSettings.Instance.BarrelClickDelay);
        }
    }
}
