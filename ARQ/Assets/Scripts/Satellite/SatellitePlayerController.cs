using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatellitePlayerController : MonoBehaviour {

    public bool isBeingControlled = false;
	
	void Update () {
		if (isBeingControlled)
        {
            this.transform.Rotate(Vector3.forward, -Input.GetAxis("Horizontal"));
        }
	}
}
