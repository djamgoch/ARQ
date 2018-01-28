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
		//this.transform.GetComponentInParent<Transform>().
		Vector3 normDir = (this.transform.position - planet.position).normalized;
		//normZAngle = Quaternion.Euler(normDir).eulerAngles.z;
		Vector3 currDir = this.transform.up.normalized;
		relativeZAngle = Quaternion.FromToRotation(normDir, currDir).eulerAngles.z;
		normZAngle = 0.0f;
		Debug.Log(relativeZAngle);
		//relativeZAngle = this.rotation
		//relativeZAngle = 0.0f;
	}

	void Update () {
		if (isBeingControlled)
        {
			float zInput = -Input.GetAxis("Horizontal") * Time.deltaTime * SATELLITE_ROTATION_SPEED;
			float newZAngle = relativeZAngle + zInput;
			if (newZAngle > -70.0f && newZAngle < 70.0f)
			{
				this.transform.Rotate(Vector3.forward, zInput);
				relativeZAngle = newZAngle;
			}
		}
	}

    public void SetAsCurrentSatellite()
    {
        LevelManager.instance.SetCurrentSatellite(this);
    }
}
