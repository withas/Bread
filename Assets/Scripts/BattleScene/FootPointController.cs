using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootPointController : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other) {
        GameObject otherObject = other.gameObject;

        if (otherObject.tag == "Ground") {
            this.transform.parent.gameObject.GetComponent<PlayerController>().OnGround();
        }
    }
}
