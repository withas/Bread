using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchController : MonoBehaviour {
    // 技の性能
    [SerializeField] private int power = 10; // 威力
    [SerializeField] private float freezingTime = 0.3f; // 硬直時間

    public int GetPower() { return this.power; }

    private void OnCollisionEnter2D(Collision2D other) {
        GameObject otherObject = other.gameObject;

        if (otherObject.tag == "Player") {
            PlayerController hitPlayer = otherObject.GetComponent<PlayerController>();
            hitPlayer.OnDamage(this.power, this.freezingTime);
        }
    }
}
