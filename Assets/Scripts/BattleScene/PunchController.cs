using UnityEngine;

public sealed class PunchController : MonoBehaviour
{
    // 技の性能
    [SerializeField]
    private int power = 10; // 威力

    [SerializeField]
    private float freezingTime = 0.3f; // 硬直時間

    private void OnCollisionEnter2D(Collision2D other)
    {
        var otherObject = other.gameObject;
        if (otherObject.tag == "Player" && otherObject.TryGetComponent<PlayerController>(out var hitPlayer))
        {
            hitPlayer.OnDamage(this.power, this.freezingTime);
        }
    }
}
