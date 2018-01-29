using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscapeMenu : MonoBehaviour {

    public Canvas menu;
    private GameObject panel;

    void Start()
    {
        panel = menu.transform.GetChild(0).gameObject;
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panel.SetActive(!panel.activeSelf);
        }
	}
}
