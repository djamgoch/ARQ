using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetTransmitterComponent : MonoBehaviour {

    public const float MAX_TRANSMISSION_DISTANCE = 150f; // TODO : Move this somewhere else

    private PlanetComponent planetComponent;
    private GameObject transmissionRendererPrefab;

    private TransmissionRenderer planetTransmission;    // The transmission coming from the planet
    private TransmissionRenderer satelliteTransmission; // The transmission bouncing off the satellite

    private GameObject satellite;
    private Vector3 dirToSatellite;
    private Vector3 dirReflectOffSatellite;
    private TransmissionReceiverComponent currentReceiver;

    void Awake()
    {
        planetComponent = this.GetComponent<PlanetComponent>();
        transmissionRendererPrefab = Resources.Load("TransmissionLineRenderer") as GameObject;
    }

    void Start()
    {
        satellite = planetComponent.satellite.gameObject;

        GameObject planetTransmissionObj = Instantiate(transmissionRendererPrefab, this.transform.position, Quaternion.identity);
        planetTransmission = planetTransmissionObj.GetComponent<TransmissionRenderer>();

        GameObject satelliteTransmissionObj = Instantiate(transmissionRendererPrefab, this.transform.position, Quaternion.identity);
        satelliteTransmission = satelliteTransmissionObj.GetComponent<TransmissionRenderer>();
    }

	// Update is called once per frame
	void Update () {
        // Calculate the direction from this planet to it's coupled satellite
        dirToSatellite = satellite.transform.position - this.transform.position;

        // Calculate the direction of the ray reflected off the satellite using its normal
        RaycastHit satelliteHitInfo;
        Physics.Raycast(this.transform.position, dirToSatellite, out satelliteHitInfo);
        dirReflectOffSatellite = Vector3.Reflect(dirToSatellite, satelliteHitInfo.normal).normalized;

        // Render the transmimssion
        planetTransmission.SetPositions(this.transform.position, satellite.transform.position);

        // Check for object hit by reflected ray
        RaycastHit reflectedHitInfo;
        bool objectWasHit = Physics.Raycast(satellite.transform.position, dirReflectOffSatellite, out reflectedHitInfo, MAX_TRANSMISSION_DISTANCE);

        // If an object was hit and it wasn't this planet
        if (objectWasHit)
        {
            satelliteTransmission.SetPositions(satellite.transform.position, reflectedHitInfo.point);

            if (currentReceiver != null && reflectedHitInfo.collider.gameObject != currentReceiver.gameObject)
            {
                currentReceiver.TransmissionExit();
                currentReceiver = null;
            }

            if (reflectedHitInfo.collider.gameObject != this.gameObject)
            {
                // Try to get its TransmissionReceiverComponent and call its ReceiveTransmission function
                TransmissionReceiverComponent receiverComponent = reflectedHitInfo.collider.GetComponent<TransmissionReceiverComponent>();
                if (receiverComponent != null)
                {
                    receiverComponent.TransmissionEnter();
                    currentReceiver = receiverComponent;
                }
            }
        }
        else
        {
            satelliteTransmission.SetPositions(satellite.transform.position, satellite.transform.position + (dirReflectOffSatellite * 500f));

            if (currentReceiver != null)
            {
                currentReceiver.TransmissionExit();
                currentReceiver = null;
            }
        }
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && planetComponent.satellite.isBeingControlled)
        {
            if (currentReceiver != null)
            {
                AudioManager.instance.PlaySFX("successplanet1");
                currentReceiver.ReceiveTransmission(this);
            }
            else
            {
                AudioManager.instance.PlaySFX("reflectfail", .5f);
            }
        }
    }
}
