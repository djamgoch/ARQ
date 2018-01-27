using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatellitePlayerController : MonoBehaviour {

    public const float SATELLITE_ROTATION_SPEED = 15f;
    public bool isBeingControlled = false;
	
	void Update () {
		if (isBeingControlled)
        {
            this.transform.Rotate(Vector3.forward, -Input.GetAxis("Horizontal") * Time.deltaTime * SATELLITE_ROTATION_SPEED);
        }
	}

    public void SetAsCurrentSatellite()
    {
        LevelManager.instance.SetCurrentSatellite(this);
    }
}
