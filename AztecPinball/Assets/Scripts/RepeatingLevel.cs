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
        numOfSpawnPointsOnStairs = startPoint.childCount;
        for (int i = 0; i < 10; i++) {
            Spawn(startPoint.transform.position);
            startPoint.transform.position += (refPoint2.position - refPoint1.position);
            PickTraps(spawnedStairs[i]);
        }


    }

    public void Spawn(Vector2 pos) {
        Vector3 start = pos;

        // spawn one stair
        Transform stair = Instantiate(stairPref);
        stair.position = start;
        start += (refPoint2.position - refPoint1.position);

        startPoint.transform.position = stair.position;
        spawnedStairs.Add(stair);

        // spawn obstacles for stairs
        // all obstacles as children, disabled.
        for (int i = 0; i < obstaclePrefs.Length; i++) {
            for (int k = 0; k < numOfSpawnPointsOnStairs; k++) {
                // in scene, stairs have n child empty game objects for references where traps can spawn.
                Transform obstacle = Instantiate(obstaclePrefs[i],
                    stair.GetChild(k).position, obstaclePrefs[i].rotation);
                obstacle.gameObject.SetActive(false);
                obstacle.gameObject.transform.parent = stair.GetChild(k);
            }
        }
        
    }

    public void PickTraps(Transform stair) {
        int n = numOfSpawnPointsOnStairs; // reduce to make stairs emptier
        float trapAppearChance = 0.5f;

        for (int i = 0; i < numOfSpawnPointsOnStairs; i++) {
            Transform t = stair.GetChild(i);
            // disable all traps, then activate N, trap or nothing.
            for (int k = 0; k < t.childCount; k++) {
                t.GetChild(k).gameObject.SetActive(false);
            }
            if (Random.Range(0f, 1f) >= trapAppearChance) {
                t.GetChild(Random.Range(0, t.childCount)).gameObject.SetActive(true);
            }
        }
    }
    
    // Update is called once per frame
    void Update () {
        // TODO: camera should follow falling body, not move in dir.
        Camera.main.transform.Translate(
            (refPoint2.position - refPoint1.position).normalized * speed * Time.deltaTime, Space.World);

        // move stairs at the top to the bottom.
        for (int i = 0; i < numOfSpawnPointsOnStairs; i++) {
            if (spawnedStairs[i].position.y > Camera.main.transform.position.y+10) {
                spawnedStairs[i].position = spawnedStairs[spawnedStairs.Count - 1].position + (refPoint2.position - refPoint1.position);
                spawnedStairs.Add(spawnedStairs[i]);
                spawnedStairs.RemoveAt(i);

                // Update traps.
                for (int k = 0; k < spawnedStairs.Count; k++) {
                    PickTraps(spawnedStairs[spawnedStairs.Count-1]);
                }
            }
        }
	}

}
