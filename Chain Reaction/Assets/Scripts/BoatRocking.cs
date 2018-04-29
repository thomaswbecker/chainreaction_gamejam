using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatRocking : MonoBehaviour {
    public GameObject boat;

    public float maxRock;

    public float cycleTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float cyclePoint = Mathf.Sin(Time.timeSinceLevelLoad * 2 * Mathf.PI / cycleTime) * 1.2F;

        if(cyclePoint > 1)
        {
            cyclePoint = 1;
        }
        else if(cyclePoint < -1)
        {
            cyclePoint = -1;
        }

        float newZ = cyclePoint * maxRock;

        boat.transform.eulerAngles = new Vector3(0, 0, newZ);
	}
}
