using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehavior : MonoBehaviour {

    Vector3 direction;
    float speed;
    GameObject planet;

	// Use this for initialization
	void Start () {
        planet = findNearestPlanet();
        GetComponent<Rigidbody>().velocity = Vector3.zero;
	}

    private void OnCollisionEnter(Collision collision)
    {
        //if the collided object is a planet, do something
        //if signal hits the asteroid, destroy it instead
        //Destroy(gameObject);
    }

    GameObject findNearestPlanet()
    {
        GameObject tmin = null;
        float nearestDistSqr = Mathf.Infinity;
        GameObject[] taggedGameObjects = GameObject.FindGameObjectsWithTag("planet");
        GameObject nearestObject = null;
        foreach (GameObject gb in taggedGameObjects)
        {
            float dist = Vector3.Distance(gb.transform.position, transform.position);
            if (dist < nearestDistSqr)
            {
                tmin = gb;
                nearestDistSqr = dist;
            }
        }
        return tmin;
    }
}
