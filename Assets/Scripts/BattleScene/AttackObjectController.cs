using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackObjectController : MonoBehaviour {
    const int PLAYER_LAYER = 9; // プレイヤーレイヤ

    // 技の性能
    [SerializeField] private int power = 5; // 威力
    [SerializeField] private float freezingTime = 0.8f; // 硬直時間

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    // アニメーションの最後に呼び出す
    public void AnimationEnd() {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        GameObject otherObject = other.gameObject;

        if (otherObject.layer == PLAYER_LAYER) {
            PlayerController hitPlayer = otherObject.GetComponent<PlayerController>();
            hitPlayer.OnDamage(this.power, this.freezingTime);
        }
    }
}
