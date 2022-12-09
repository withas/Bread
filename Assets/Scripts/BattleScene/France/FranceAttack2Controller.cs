using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FranceAttack2Controller : MonoBehaviour {
    // 技の性能
    [SerializeField] private int power = 5; // 威力
    [SerializeField] private float freezingTime = 0.8f; // 硬直時間

    public int GetPower() { return this.power; }

    // アニメーションの最後に呼び出す
    public void AnimationEnd() {
        this.transform.parent.gameObject.GetComponent<FranceController>().EndAttack2();
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        GameObject otherObject = other.gameObject;

        if (otherObject.tag == "Player" && otherObject.transform != this.transform.parent) {
            PlayerController hitPlayer = otherObject.GetComponent<PlayerController>();
            hitPlayer.OnDamage(this.power, this.freezingTime);
        }
    }
}
