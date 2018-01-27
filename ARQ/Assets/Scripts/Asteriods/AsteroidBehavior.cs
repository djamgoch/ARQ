using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehavior : MonoBehaviour {

    Vector3 direction;
    float speed;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
	}

    private void OnCollisionEnter(Collision collision)
    {
        //if the collided object is a planet, do something
    }
}
