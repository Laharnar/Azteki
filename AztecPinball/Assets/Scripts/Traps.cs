using System;
using System.Collections;
using UnityEngine;
public class Traps : MonoBehaviour {
    public Vector3 forceDirection = Vector3.up;


    private void Update() {
        
    }

    private void OnCollisionEnter(Collision collision) {
        GameManager.m.Record(collision.transform.root);
        Rigidbody rig = collision.transform.GetComponent<Rigidbody>();
        if (rig) {
            rig.AddForce(forceDirection, ForceMode.Impulse);
        }
    }
}
