using System.Collections.Generic;
using UnityEngine;

public class GameManager:MonoBehaviour {
    public static GameManager m;

    public int counter = 0;
    public List<Transform> recordedCollisions = new List<Transform>();

    private void Start() {
        m = this;
    }

    internal void Record(Transform root) {
        if (!recordedCollisions.Contains(root)) {
            recordedCollisions.Add(root);
        }
    }

    private void Update() {
        counter = recordedCollisions.Count;
    }
}
