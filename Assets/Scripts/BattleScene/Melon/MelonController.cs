using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelonController : PlayerController {
    // Attack2
    [SerializeField] private GameObject attack2Prefab;
    [SerializeField] private GameObject attack2Point; // Attack2生成位置

    private GameObject attack2Object; // Attack2のオブジェクト

    // Start is called before the first frame update
    new void Start() {
        base.Start();
    }

    // Update is called once per frame
    new void Update() {
        base.Update();
    }

    // Attack2関係

    // キャラクターのAttack2のアニメーションの中で呼ばれる
    public void StartAttack2() {
        this.attack2Object = Instantiate(this.attack2Prefab, this.attack2Point.transform.position, this.transform.rotation);

        // 子オブジェクトに設定する
        this.attack2Object.transform.parent = this.transform;
    }

    public void EndAttack2() {
        this.animator.SetTrigger("EndAttack2");
    }

    override public void OnDamage(int damage, float freezingTime) {
        if (this.attack2Object != null) Destroy(this.attack2Object);

        base.OnDamage(damage, freezingTime);
    }
}
