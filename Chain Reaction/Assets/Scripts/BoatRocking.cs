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
	void Update () {
        float cyclePoint = Mathf.Sin(Time.fixedTime * 2 * Mathf.PI / cycleTime);

        float newZ = cyclePoint * maxRock;

        Debug.Log(newZ);

        boat.transform.eulerAngles = new Vector3(0, 0, newZ);
	}
}
