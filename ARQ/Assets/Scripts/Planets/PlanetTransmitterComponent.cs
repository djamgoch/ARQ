using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetTransmitterComponent : MonoBehaviour {

    public const float MAX_TRANSMISSION_DISTANCE = 150f; // TODO : Move this somewhere else

    private PlanetComponent planetComponent;
    private GameObject satellite;
    private Vector3 dirToSatellite;
    private Vector3 dirReflectOffSatellite;

    void Awake()
    {
        planetComponent = this.GetComponent<PlanetComponent>();
    }

    void Start()
    {
        satellite = planetComponent.satellite.gameObject;
    }

	// Update is called once per frame
	void Update () {
        // Calculate the direction from this planet to it's coupled satellite
        dirToSatellite = satellite.transform.position - this.transform.position;

        // Calculate the direction of the ray reflected off the satellite using its normal
        RaycastHit satelliteHitInfo;
        Physics.Raycast(this.transform.position, dirToSatellite, out satelliteHitInfo);
        dirReflectOffSatellite = Vector3.Reflect(dirToSatellite, satelliteHitInfo.normal).normalized;

        // Check for object hit by reflected ray
        RaycastHit reflectedHitInfo;
        bool objectWasHit = Physics.Raycast(satellite.transform.position, dirReflectOffSatellite, out reflectedHitInfo, MAX_TRANSMISSION_DISTANCE);

        // If an object was hit and it wasn't this planet
        if (objectWasHit && reflectedHitInfo.collider.gameObject != this.gameObject)
        {
            // Try to get its TransmissionReceiverComponent and call its ReceiveTransmission function
            TransmissionReceiverComponent receiverComponent = reflectedHitInfo.collider.GetComponent<TransmissionReceiverComponent>();
			if (receiverComponent != null && receiverComponent.isAlreadyActivated == false && Input.GetKeyDown(KeyCode.Space))
            {
                receiverComponent.ReceiveTransmission(this);
            }
        }

        // For debugging to visualize the physics rays
        Debug.DrawRay(this.transform.position, dirToSatellite, Color.green);
        Debug.DrawRay(satellite.transform.position, dirReflectOffSatellite * MAX_TRANSMISSION_DISTANCE, Color.green);
    }
}
