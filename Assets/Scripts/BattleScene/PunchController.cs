using UnityEngine;

public sealed class PunchController : MonoBehaviour
{
    // 技の性能
    [SerializeField]
    private CharaStatusData charaStatusData;

    private void OnCollisionEnter2D(Collision2D other)
    {
        var otherObject = other.gameObject;
        if (otherObject.tag == "Player" && otherObject.TryGetComponent<PlayerController>(out var hitPlayer))
        {
            hitPlayer.OnDamage(charaStatusData.Attack1Power, charaStatusData.Attack1FreezingTime);
        }
    }
}
