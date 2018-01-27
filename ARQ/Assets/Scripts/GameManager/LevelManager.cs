using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manages settings that are shared during the level (e.g. the currently controlled satellite)
public class LevelManager : MonoBehaviour {

    public SatellitePlayerController currentSatellite;  // The satellite that is currently being controlled

    void Start()
    {
        // Turn on the current satellite at the start of the scene (in case it isn't currently on)
        currentSatellite.isBeingControlled = true;
    }

    // Changes control over to a new satellite, disabling control of the previous one
    public void SetCurrentSatellite(SatellitePlayerController newSatellite)
    {
        currentSatellite.isBeingControlled = false;

        newSatellite.isBeingControlled = true;
        currentSatellite = newSatellite;
    }
}
