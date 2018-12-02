using System;
using System.Collections;
using UnityEngine;
public class Traps : MonoBehaviour {
    public Vector3 forceDirection = Vector3.up;


    private void Update() {
        
    }

    private void OnTriggerEnter(Collider collision) {
        GameManager.m.Record(collision.transform.root);
        Rigidbody rig = collision.GetComponent<Rigidbody>();
        if (rig) {
            rig.AddForce(forceDirection);
        }
    }
}
