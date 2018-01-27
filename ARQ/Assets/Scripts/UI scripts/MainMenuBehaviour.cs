using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuBehaviour : MonoBehaviour {

	public string Level_1_Scene_Name = "Level 1";

	private Scene currentScene;

	// Use this for initialization
	void Start () {
		Cursor.visible = true;
		currentScene = SceneManager.GetActiveScene();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/* Starts the game from level 1.
	 * Usually called by Start button's button (script) component via OnClick().
	 */
	public void StartNewGame()
	{
		Cursor.visible = false;
		SceneManager.LoadScene(Level_1_Scene_Name);
		//SceneManager.LoadScene(currentScene.buildIndex + 1);
	}

	/* Exits the game.
	 * !!! May or may not be implemented
	 * Usually called by Quit Button's button (script) component via OnClick().
	 * NOTE: The Unity Editor will ignore this function, so don't worry if nothing happens
	 * during testing (unless you're testing with a build).
	 */
	public void QuitGame()
	{
		Application.Quit();
	}
}
