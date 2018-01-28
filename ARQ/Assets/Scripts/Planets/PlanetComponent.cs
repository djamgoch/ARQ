using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manages the state of the planet (e.g. its coupled satellite)
public class PlanetComponent : MonoBehaviour {

    public SatellitePlayerController satellite; // The satellite coupled with this planet

    private PlanetTransmitterComponent planetTransmitter;

	private void Awake()
	{
		satellite.planet = this.transform;
        planetTransmitter = this.GetComponent<PlanetTransmitterComponent>();
        planetTransmitter.enabled = false;
	}

    public void ActivatePlanet()
    {
        this.satellite.SetAsCurrentSatellite();
        planetTransmitter.enabled = true;
        LevelManager.instance.UpdateScore();
    }
}
