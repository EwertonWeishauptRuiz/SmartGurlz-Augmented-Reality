using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour {
    
    float speed = 32;
    Rigidbody rbd;
   
    void Start () {
        rbd = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () {
        transform.Rotate((Random.Range(200, 450) * Time.deltaTime), 
                         (Random.Range(450, 650) * Time.deltaTime), 
                         (Random.Range (250, 650) * Time.deltaTime));       

        rbd.velocity = new Vector2(speed * Random.Range(0.7f, 1.5f), rbd.velocity.y);
    }

    void OnTriggerEnter() {
        Destroy(gameObject);
    }
}
