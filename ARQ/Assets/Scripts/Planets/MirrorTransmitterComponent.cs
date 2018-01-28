using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorTransmitterComponent : MonoBehaviour {

    public const float MAX_TRANSMISSION_DISTANCE = 20f; // TODO : Move this somewhere else

    //private MirrorComponent mirrorComponent;
    //private GameObject mirror;
    //public PlanetTransmitterComponent planetComp;
    //private Vector3 dirToSatellite;
    //Mirrors have a single direction they work off of.
    public Vector3 emitDirection;
    private GameObject transmissionRendererPrefab;
    private TransmissionRenderer mirrorTransmission;    // The transmission coming from the mirror
    private TransmissionReceiverComponent currentReceiver;

    void Awake()
    {
        emitDirection = emitDirection.normalized;
        transmissionRendererPrefab = Resources.Load("TransmissionLineRenderer") as GameObject;
    }

    void Start()
    {
        GameObject mirrorTransmissionObj = Instantiate(transmissionRendererPrefab, this.transform.position, Quaternion.identity);
        mirrorTransmission = mirrorTransmissionObj.GetComponent<TransmissionRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check for object hit by reflected ray
        RaycastHit reflectedHitInfo;

        // Render the transmimssion
        //mirrorTransmission.SetPositions(this.transform.position, satellite.transform.position);
        bool objectWasHit = Physics.Raycast(transform.position, emitDirection, out reflectedHitInfo, MAX_TRANSMISSION_DISTANCE);

        // If an object was hit and it wasn't this planet
        if (objectWasHit /*&& reflectedHitInfo.collider.gameObject != this.gameObject*/)
        {
            mirrorTransmission.SetPositions(this.transform.position, reflectedHitInfo.point);
            // Try to get its TransmissionReceiverComponent and call its ReceiveTransmission function
            TransmissionReceiverComponent receiverComponent = reflectedHitInfo.collider.GetComponent<TransmissionReceiverComponent>();
            if (receiverComponent != null && receiverComponent.state != TransmissionReceiverComponent.ReceiverState.ACTIVATED)
            {
                receiverComponent.ReceiveTransmission();
            }
        }
        else
        {
            mirrorTransmission.SetPositions(this.transform.position, this.transform.position + (emitDirection * 500f));

        }

        // For debugging to visualize the physics rays
        //Debug.DrawRay(this.transform.position, dirReflectOffMirror, Color.green);
        Debug.DrawRay(transform.position, emitDirection * MAX_TRANSMISSION_DISTANCE, Color.green);
    }

    
}
