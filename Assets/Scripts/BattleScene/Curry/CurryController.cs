using UnityEngine;

public sealed class CurryController : PlayerController
{
    [SerializeField]
    private GameObject attack2Prefab;

    [SerializeField]
    private GameObject attack2Point;

    private GameObject attack2Object;

    // キャラクターのAttack2のアニメーションの中で呼ばれる
    public override void StartAttack2()
    {
        this.attack2Object = Instantiate(this.attack2Prefab, this.attack2Point.transform.position, this.transform.rotation);

        // 子オブジェクトに設定する
        this.attack2Object.transform.parent = this.transform;
    }

    public override void EndAttack2()
    {
        this.animator.SetTrigger("EndAttack2");
    }

    public override void OnDamage(int damage, float freezingTime)
    {
        if (this.attack2Object != null)
        {
            Destroy(this.attack2Object);
        }

        base.OnDamage(damage, freezingTime);
    }
}
