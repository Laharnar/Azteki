using UnityEngine;

// dodaj na child bone playerja, ki ima tudi že character torso.
// - popravi spodaj TODO.
public class PlayerJumps: MonoBehaviour {

    public float forceMultiplier = 1;

    public void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            // efficient code...
            Vector3 direction = GetClosestStairCenter(transform.position).position-transform.position;
            GetComponent<Rigidbody>().AddForce(direction*forceMultiplier, ForceMode.Impulse); 
        }
    }

    Transform GetClosestStairCenter(Vector3 pos) {
        float min  = float.MaxValue;
        int c = -1;
        for (int i = 0; i < GameManager.m.level.spawnedStairs.Count; i++) {
            float x = Vector3.Distance(GameManager.m.level.spawnedStairs[i].position, pos);
            if (x < min) {
                min = x;
                c = i;
            }
        }
        return GameManager.m.level.spawnedStairs[c].GetChild(0); // TODO: SET CHILD. Whatever your transform to pull to is.
    }
}