using UnityEngine;

public sealed class CurryAttack2Controller : MonoBehaviour
{
    // 技の性能
    [SerializeField]
    private int power = 5; // 威力

    [SerializeField]
    private float freezingTime = 0.8f; // 硬直時間

    // アニメーションの最後に呼び出す
    public void AnimationEnd()
    {
        this.transform.parent.gameObject.GetComponent<CurryController>().EndAttack2();
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var otherObject = other.gameObject;
        if (otherObject.tag == "Player" && otherObject.TryGetComponent<PlayerController>(out var hitPlayer))
        {
            hitPlayer.OnDamage(this.power, this.freezingTime);
        }
    }
}
