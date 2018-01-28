using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapUI : MonoBehaviour {

    float timeToSwap;

	// Use this for initialization
	void Start () {
        timeToSwap = 10.0f;
	}
	
	// Update is called once per frame
	void Update () {

        if (timeToSwap < 0.0f)
        {
            transform.GetChild(0).gameObject.SetActive(!transform.GetChild(0).gameObject.activeSelf);
            transform.GetChild(1).gameObject.SetActive(!transform.GetChild(1).gameObject.activeSelf);
            transform.GetChild(4).gameObject.SetActive(!transform.GetChild(4).gameObject.activeSelf);
            timeToSwap = 10.0f;
        }
        else
        {
            timeToSwap -= Time.deltaTime;
        }
	}
}
