using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSynopsis : MonoBehaviour {

    bool hidden;

    // Use this for initialization
    void Start()
    {
        hidden = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.anyKey && !hidden)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            hidden = true;
        }
    }
}
