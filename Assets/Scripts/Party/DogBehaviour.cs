using UnityEngine;
using System.Collections;

public class DogBehaviour : MonoBehaviour {

    public Transform dogStart;
    public Transform dogEnd;
    public Transform dogPos;

    public GameObject Dog;

	void Update () {
        Vector3 newScale = Dog.transform.localScale;
        if (dogPos.position.x <= dogEnd.position.x) {
            newScale.z = -12;
            Dog.transform.localScale = newScale;
        }
        if (dogPos.position.x >= dogStart.position.x) {
            newScale.z = 12;
            Dog.transform.localScale = newScale;
        }
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(dogStart.position, dogEnd.position);
    }
}
