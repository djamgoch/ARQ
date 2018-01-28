using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSynopsis : MonoBehaviour {

    bool hidden;
    Transform panel;

    // Use this for initialization
    void Start()
    {
        hidden = false;
        if (transform.Find("Panel") != null)
        {
            panel = transform.Find("Panel");
        }
    }


    public void HideText()
    {
        if (!hidden)
        {
            panel.gameObject.SetActive(false);
            //transform.GetChild(1).gameObject.SetActive(false);
            hidden = true;
        }
    }
}
