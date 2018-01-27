using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransmissionParticles : MonoBehaviour {

    public GameObject[] objectsToIgnore;

    public void Initialize(GameObject[] objectsToIgnore)
    {
        foreach (var obj in objectsToIgnore)
        {
            //Physics.IgnoreCollision(this.GetComponent<ParticleSystem>(), obj.GetComponent<Collider>());
        }
    }
}
