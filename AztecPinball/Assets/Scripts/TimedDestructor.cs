using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestructor : MonoBehaviour {

	void Start()
    {
        Invoke("DestroyParticles", 3);
    }


    void DestroyParticles()
    {
        Destroy(this.gameObject);
    }
}
