using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTracker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
    
	// Update is called once per frame
	void Update () {
        Vector3 screenPosition = Input.mousePosition;
        //screenPosition.y = Camera.current.pixelHeight - screenPosition.y;
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        RaycastHit hit;
        // use a different Physics.Raycast() override if necessary
        if (Physics.Raycast(ray, out hit))
        {
            transform.LookAt(hit.point);
        }

    }
}
