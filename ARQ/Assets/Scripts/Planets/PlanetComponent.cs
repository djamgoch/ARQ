using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manages the state of the planet (e.g. its coupled satellite)
public class PlanetComponent : MonoBehaviour {

    public SatellitePlayerController satellite; // The satellite coupled with this planet

	private void Awake()
	{
		satellite.planet = this.transform;
	}

}
