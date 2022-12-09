using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelonAttack2Controller : MonoBehaviour {
    // 技の性能
    [SerializeField] private int power = 5; // 威力
    [SerializeField] private float freezingTime = 0.2f; // 硬直時間

    public int GetPower() { return this.power; }

    // アニメーションの最後に呼び出す
    public void AnimationEnd() {
        this.transform.parent.gameObject.GetComponent<MelonController>().EndAttack2();
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        GameObject otherObject = other.gameObject;

        if (otherObject.tag == "Player") {
            PlayerController hitPlayer = otherObject.GetComponent<PlayerController>();
            hitPlayer.OnDamage(this.power, this.freezingTime);
        }
    }
}
