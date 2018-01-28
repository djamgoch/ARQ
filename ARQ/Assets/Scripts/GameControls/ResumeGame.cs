using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeGame : MonoBehaviour {

    public Canvas menu;

    public void ResumePlayingGame()
    {
        menu.transform.GetChild(0).gameObject.SetActive(false);
    }
}
