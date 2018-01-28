using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatellitePlayerController : MonoBehaviour {

    public const float SATELLITE_ROTATION_SPEED = 15f;
    public bool isBeingControlled = false;
	public Transform planet;

	private float relativeZAngle;
	private float normZAngle;

	private void Start()
	{
		//Vector3 normDir = (this.transform.position - planet.position).normalized;
		Vector3 normDir = (planet.position - this.transform.position).normalized;
		Vector3 currDir = this.transform.up.normalized;
		Debug.Log(this.transform.parent.name + ": normal vector = " + normDir);
		Debug.Log(this.transform.parent.name + ": current vector = " + currDir);
		//relativeZAngle = Quaternion.FromToRotation(normDir, currDir).eulerAngles.z;
		relativeZAngle = Vector3.Angle(normDir, currDir);
		Debug.Log(name + ": relative Z angle = " + relativeZAngle);          // -190
		normZAngle = 0.0f;
	}

	void Update () {
		if (isBeingControlled)
        {
			float zInput = -Input.GetAxis("Horizontal") * Time.deltaTime * SATELLITE_ROTATION_SPEED;
			Vector3 normDir = (planet.position - this.transform.position).normalized;
			Vector3 currDir = this.transform.up.normalized;
			relativeZAngle = Vector3.Angle(normDir, currDir);
			float newZAngle = relativeZAngle;
			if (newZAngle >= -70.0f && newZAngle <= 70.0f)   // lower: -70, upper: 70
			{
				this.transform.Rotate(Vector3.forward, zInput, Space.World);
				//relativeZAngle = newZAngle;
			}
		}
	}

    public void SetAsCurrentSatellite()
    {
        LevelManager.instance.SetCurrentSatellite(this);
    }
}
