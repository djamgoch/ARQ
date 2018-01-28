using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscapeMenu : MonoBehaviour {

    public Canvas menu;

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) && !menu.transform.GetChild(0).gameObject.activeSelf)
        {
            menu.transform.GetChild(0).gameObject.SetActive(true);
        }
	}
}
