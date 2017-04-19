using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour {
    
    float speed = 32;
    Rigidbody rbd;

    float timerToDetroy = 25f;
    float launchBallTimer = 2f;

    public bool alreadyLaunched;

    void Start () {
        rbd = GetComponent<Rigidbody>();
        alreadyLaunched = false;
	}
	
	void FixedUpdate () {
        BallRotation();


        if (launchBallTimer <= 0 && !alreadyLaunched) {            
            BallLaunch();
            alreadyLaunched = true;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            BallLaunch();
        }
        if (timerToDetroy <= 0) {
            Destroy(gameObject);
        }

        timerToDetroy -= Time.deltaTime;
        launchBallTimer -= Time.deltaTime;
    }

    void OnTriggerEnter() {
        Destroy(gameObject);
    }

    void BallLaunch() {
        rbd.velocity = new Vector3(Random.Range(9, 20),
                           Random.Range(5, 15),
                           Random.Range(-5, 5));
    }

    void BallRotation() {
        transform.Rotate((Random.Range(20, 45) * Time.deltaTime),
                         (Random.Range(50, 70) * Time.deltaTime),
                         (Random.Range(20, 80) * Time.deltaTime));
    }
}
