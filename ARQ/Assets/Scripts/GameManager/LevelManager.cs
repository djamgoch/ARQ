using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Manages settings that are shared during the level (e.g. the currently controlled satellite)
public class LevelManager : MonoBehaviour {

    public static LevelManager instance;
	public int numberOfPlanetsToActivate = 0;

	private int numOfPlanetsActivated;
	private bool playerBeatLevel;
	public PlanetComponent startingPlanet;
    private SatellitePlayerController currentSatellite;  // The satellite that is currently being controlled
	private Scene currentScene;  // represents the current level

    void Awake()
    {
        instance = this;

        currentSatellite = startingPlanet.satellite;
		numOfPlanetsActivated = 0;
		playerBeatLevel = false;
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

	public void UpdateScore()
	{
		++numOfPlanetsActivated;

		if (numOfPlanetsActivated >= numberOfPlanetsToActivate)
			playerBeatLevel = true;
	}

	public void BeginNextLevel()
	{
		if (playerBeatLevel)
		{
			if (AudioManager.instance != null)
			{
				AudioManager.instance.PlayNextARQStage();
			}
			SceneManager.LoadScene(currentScene.buildIndex + 1);
		}
		else
		{
			LosePanelBehaviour lose = FindObjectOfType<Canvas>().GetComponent<LosePanelBehaviour>();
			lose.ShowLosePanel();
		}
	}
}
