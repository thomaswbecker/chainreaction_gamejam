using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatRocking : MonoBehaviour {
    public GameObject boat;

    public float maxRock;

    public float cycleTime;
    public bool useCustomCurve = false;
    public bool overrideGlobalCurve = false;

    public AnimationCurve boatRockOverride;
	// Use this for initialization
	void Start () {
        if (!overrideGlobalCurve)
            boatRockOverride = GameSettings.Instance.BoatRockCurve;
        if (boatRockOverride == null)
            useCustomCurve = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (useCustomCurve && boatRockOverride != null)
        {
            float cycleT = ((Time.timeSinceLevelLoad / cycleTime)) % 1f;
            float halfCycleT = (((Time.timeSinceLevelLoad / cycleTime)) % 0.5f) * 2f;


            float doublepingpongT = 1 - Mathf.Abs(1 - 2 * halfCycleT);
            float rock = boatRockOverride.Evaluate(doublepingpongT);
            if (cycleT > 0.5f)
                rock = -rock;
            rock = rock * maxRock;

            boat.transform.eulerAngles = new Vector3(0, 0,rock);
            return;
        }
        
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
