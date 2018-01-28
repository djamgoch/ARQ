using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuBehaviour : MonoBehaviour {

	public string Level_1_Scene_Name = "Level 1";
    public string Intro_Scene_Name = "Intro Scene";

    public void GoToIntro()
    {
        AudioManager.instance.PlaySFX("ARQstartgame2");
        SceneManager.LoadScene(Intro_Scene_Name);
    }

	/* Starts the game from level 1.
	 * Usually called by Start button's button (script) component via OnClick().
	 */
	public void StartNewGame()
	{
        AudioManager.instance.PlaySFX("ARQstartgame2");
        AudioManager.instance.PlayBGM("ARQstage1");

		SceneManager.LoadScene(Level_1_Scene_Name);
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
