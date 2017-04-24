using UnityEngine;
using System.Collections;

public class BallonSpawn : MonoBehaviour {

    public Transform[] spawnLocations;
    public GameObject[] ballonsPrefabs;
    public GameObject[] ballonsClones;   

    public float respawnTimer;
    public float respawnTimer2;

    void Awake() {
        SpawnBallon();
        SpawnBallon2();
    }


    void Update() {
        if (respawnTimer <= 0) {
            SpawnBallon();
            respawnTimer = Random.Range (4, 6);
        }
        if (respawnTimer2 <= 0) {
            SpawnBallon2();
            respawnTimer2 = Random.Range(5, 7);
        }

        respawnTimer -= Time.deltaTime;
        respawnTimer2 -= Time.deltaTime;
    }

    void SpawnBallon() {
        ballonsClones[0] = Instantiate(ballonsPrefabs[0], spawnLocations[0].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        ballonsClones[2] = Instantiate(ballonsPrefabs[2], spawnLocations[2].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        ballonsClones[1] = Instantiate(ballonsPrefabs[1], spawnLocations[4].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
    }
    void SpawnBallon2() {
        ballonsClones[1] = Instantiate(ballonsPrefabs[1], spawnLocations[1].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        ballonsClones[0] = Instantiate(ballonsPrefabs[0], spawnLocations[3].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        ballonsClones[2] = Instantiate(ballonsPrefabs[2], spawnLocations[5].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
    }

}



