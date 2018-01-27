using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteriod : MonoBehaviour {

    public GameObject Asteriod;
    public Vector3 SpawnPoint;
    public float spawnTimer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    
    //Spawn asteriod
    void Spawn()
    {
        Instantiate(Asteriod, SpawnPoint, Asteriod.transform.rotation);
    }
}
