using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour {

    float rotateX;
    float rotateY;
    float rotateZ;

	// Use this for initialization
	void Start () {
        rotateX = Random.Range(0.0f, 1.0f);
        rotateY = Random.Range(0.0f, 1.0f);
        rotateZ = Random.Range(0.0f, 1.0f);
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(rotateX, rotateY, rotateZ);
	}
}
