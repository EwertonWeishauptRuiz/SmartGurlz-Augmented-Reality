using UnityEngine;
using System.Collections;

public class BallonBehaviour : MonoBehaviour {
	void Update () {
        Physics.gravity = new Vector3(0,Random.Range(7, 12), 0);
    }

    void OnCollisionEnter() {
        Destroy(gameObject);
    }
}
