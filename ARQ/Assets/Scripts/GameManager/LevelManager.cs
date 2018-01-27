using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Manages settings that are shared during the level (e.g. the currently controlled satellite)
public class LevelManager : MonoBehaviour {

    public static LevelManager instance;

    public PlanetComponent startingPlanet;
    private SatellitePlayerController currentSatellite;  // The satellite that is currently being controlled
	private Scene currentScene;  // represents the current level

    void Awake()
    {
        instance = this;

        currentSatellite = startingPlanet.satellite;
    }

    void Start()
    {
        // Turn on the current satellite at the start of the scene (in case it isn't currently on)        
        startingPlanet.GetComponent<TransmissionReceiverComponent>().ReceiveTransmission();
		currentScene = SceneManager.GetActiveScene();
    }

    // Changes control over to a new satellite, disabling control of the previous one
    public void SetCurrentSatellite(SatellitePlayerController newSatellite)
    {
        currentSatellite.isBeingControlled = false;

        newSatellite.isBeingControlled = true;
        currentSatellite = newSatellite;
    }

	public void BeginNextLevel()
	{
		SceneManager.LoadScene(currentScene.buildIndex + 1);
	}
}
