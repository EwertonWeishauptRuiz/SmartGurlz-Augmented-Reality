using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallKill : MonoBehaviour {


    float speed = 20;
    Rigidbody rbd;
    // Use this for initialization
    void Start () {
        rbd = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up * 80 * Time.deltaTime);
        rbd.velocity = new Vector2(speed, rbd.velocity.y);
    }

    void OnTriggerEnter() {
        Destroy(gameObject);
    }
}
