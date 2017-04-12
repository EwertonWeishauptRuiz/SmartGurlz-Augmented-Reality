using UnityEngine;
using System.Collections;

public class BallonsBehaviour : MonoBehaviour {

    public Transform[] spawnLocations;
    public GameObject[] ballonsPrefabs;
    public GameObject[] ballonsClones;   

    float respawnTimer = 1f;
    float respawnTimer2 = 1f;

    void Start () {
        SpawnBallon();
        SpawnBallon2();
    }

	void Update () {
        if(respawnTimer <= 0) {
            SpawnBallon();
            respawnTimer = 6;
        }
        if(respawnTimer2 <= 0){
            SpawnBallon2();
            respawnTimer2 = 7;
        }
        respawnTimer  -= Time.deltaTime;
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



