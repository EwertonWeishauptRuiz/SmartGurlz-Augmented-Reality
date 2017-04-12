using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour {

    public Transform ballStart;
    public Transform ballEnd;

    public GameObject[] ballPrefab;
    public GameObject[] ballClone;
    // Update is called once per frame

    public float spawnTimer = 3;
	void Update () {
        if(spawnTimer <= 0) {
            SpawnBall();
            spawnTimer = 3;
        }
        spawnTimer -= Time.deltaTime;
    }	
    void SpawnBall() {
        ballClone[0] = Instantiate(ballPrefab[0], ballStart.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;       
    }

}
