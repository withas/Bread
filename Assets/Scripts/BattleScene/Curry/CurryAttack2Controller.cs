using UnityEngine;

public sealed class CurryAttack2Controller : MonoBehaviour
{
    [SerializeField]
    private CharaStatusData charaStatusData;

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
            hitPlayer.OnDamage(charaStatusData.Attack2Power, charaStatusData.Attack2FreezingTime);
        }
    }
}
