﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MirrorComponent : MonoBehaviour {
    public bool isAlreadyActivated = false;     // Prevent this object from being activated multiple times - could result in unwanted behavior if we want
                                                // reusable receivers (e.g. an extender that can be used by multiple transmissions)
    public UnityEvent OnReceiveTransmission;    // Specify in the editor what happens when this object receives a transmission

    // Called when a PlanetTransmitterComponent's raycast hits this object
    // sendingPlanet parameter currently unused but could be used for behavior for receiving specific transmissions from specific planets
    /*public void ReceiveTransmission(PlanetTransmitterComponent sendingPlanet)
    {
        OnReceiveTransmission.Invoke(); // Call all the functions under this event in the editor
        isAlreadyActivated = true;      // Toggle this on, so that it can't get activated again (temp to avoid multiple physics calls per frame)

        // For debugging
        Debug.LogFormat("Activated by {0}!", sendingPlanet.name);
        this.GetComponent<MeshRenderer>().material.color = Color.green;
    }*/
    public void ReflectTransmission(PlanetTransmitterComponent sendingPlanet)
    {
        OnReceiveTransmission.Invoke(); // Call all the functions under this event in the editor
        isAlreadyActivated = true;      // Toggle this on, so that it can't get activated again (temp to avoid multiple physics calls per frame)

        // For debugging
        Debug.LogFormat("Activated by {0}!", sendingPlanet.name);
        this.GetComponent<MeshRenderer>().material.color = Color.green;
    }
}
