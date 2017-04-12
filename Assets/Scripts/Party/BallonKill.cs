using UnityEngine;
using System.Collections;

public class BallonKill : MonoBehaviour {
	void Update () {
        Physics.gravity = new Vector3(0, 10.0f, 0);
    }

    void OnCollisionEnter() {
        Destroy(gameObject);
    }
}
