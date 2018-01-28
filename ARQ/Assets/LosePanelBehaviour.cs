using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosePanelBehaviour : MonoBehaviour {

    public GameObject losePanel;

	// Use this for initialization
	void Start () {
        losePanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ShowLosePanel()
	{
        losePanel.SetActive(true);
	}
}
