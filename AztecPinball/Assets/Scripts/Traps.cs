using System;
using System.Collections;
using UnityEngine;
public class Traps : MonoBehaviour {

    private void OnTriggerEnter(Collider collision) {
        GameManager.m.Record(collision.transform.root);
    }
}
