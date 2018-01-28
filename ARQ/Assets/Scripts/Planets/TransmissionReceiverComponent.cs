using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Manages receving transmissions on this object via the OnReceiveTransmission UnityEvent
// Currently only attached to planets, but can be attached to other objects in the future.
public class TransmissionReceiverComponent : MonoBehaviour {
    public bool isAlreadyActivated = false;     // Prevent this object from being activated multiple times - could result in unwanted behavior if we want
                                                // reusable receivers (e.g. an extender that can be used by multiple transmissions)
    public ParticleSystem activationGlow;

    public UnityEvent OnReceiveTransmission;    // Specify in the editor what happens when this object receives a transmission

    private ParticleSystem.MainModule activationGlowModule;

    void Awake()
    {
        activationGlowModule = activationGlow.main;
    }

    public void EnableGlow()
    {
        activationGlow.gameObject.SetActive(true);
    }

    public void EnableGlow(Color color)
    {
        this.EnableGlow();
        activationGlowModule.startColor = color;
    }

    public void DisableGlow()
    {
        activationGlow.gameObject.SetActive(false);
    }

    // Called when a PlanetTransmitterComponent's raycast hits this object
    // sendingPlanet parameter currently unused but could be used for behavior for receiving specific transmissions from specific planets
    public void ReceiveTransmission(PlanetTransmitterComponent sendingPlanet)
    {
        OnReceiveTransmission.Invoke(); // Call all the functions under this event in the editor
        isAlreadyActivated = true;      // Toggle this on, so that it can't get activated again (temp to avoid multiple physics calls per frame)
        EnableGlow(Color.green);
        // For debugging
        //Debug.LogFormat("Activated by {0}!", sendingPlanet.name);
        //this.GetComponent<MeshRenderer>().material.color = Color.green;
    }
    public void ReceiveTransmission()
    {
        OnReceiveTransmission.Invoke(); // Call all the functions under this event in the editor
        isAlreadyActivated = true;      // Toggle this on, so that it can't get activated again (temp to avoid multiple physics calls per frame)
        EnableGlow(Color.green);
        // For debugging
        //this.GetComponent<MeshRenderer>().material.color = Color.green;
    }
}
