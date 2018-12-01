using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingLevel : MonoBehaviour {

    public Transform refPoint1, refPoint2;
    public float speed = 1f;
    public Transform startPoint;
    int active = 0;
    public List<Transform> spawnedStairs = new List<Transform>();
    List<Vector3> positions = new List<Vector3>();
    public Transform[] obstaclePrefs;

    public Transform stairPref;
    public int numOfSpawnPointsOnStairs = 2;

    // Use this for initialization
    void Start () {
        Spawn(startPoint.transform.position);
    }

    public void Spawn(Vector2 pos) {
        Vector3 start = pos;
        for (int i = 0; i < 10; i++) {
            Transform t = Instantiate(stairPref);
            t.position = start;
            start += (refPoint2.position - refPoint1.position);

            startPoint.transform.position = t.position;
            spawnedStairs.Add(t);
        }
    }
    public void SpawnObstacle(Transform stairs) {

        // check if pos is already taken
        Vector3 pos = stairs.GetChild(Random.Range(0, numOfSpawnPointsOnStairs)).position;
        positions.Add(pos);
        for (int i = 0; i < positions.Count; i++) {
            if (positions[i] == pos) {
                return;
            }
        }

        // in scene, stairs have 2 child empty game objects for references where stuff can spawn.
        Instantiate(obstaclePrefs[Random.Range(0, obstaclePrefs.Length)],
            pos, new Quaternion());

        // some terrible code.
        if (positions.Count > 100) {
            for (int i = 0; i < 10; i++) {
                positions.RemoveAt(0);
            }
        }
    }
    // Update is called once per frame
    void Update () {
        // TODO: camera should follow falling body, not move in dir.
        Camera.main.transform.Translate(
            (refPoint2.position - refPoint1.position).normalized * speed * Time.deltaTime, Space.World);

        for (int i = 0; i < spawnedStairs.Count; i++) {
            if (spawnedStairs[i].position.y > Camera.main.transform.position.y -20) {
                for (int j = 0; j < numOfSpawnPointsOnStairs; j++) {
                    SpawnObstacle(spawnedStairs[i].transform);
                }
            }
        }
        for (int i = 0; i < numOfSpawnPointsOnStairs; i++) {
            if (spawnedStairs[i].position.y > Camera.main.transform.position.y+10) {
                spawnedStairs[i].position = spawnedStairs[spawnedStairs.Count - 1].position + (refPoint2.position - refPoint1.position);
                spawnedStairs.Add(spawnedStairs[i]);
                spawnedStairs.RemoveAt(i);

            }
        }
	}

}
