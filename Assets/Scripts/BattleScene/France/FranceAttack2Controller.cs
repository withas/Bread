using UnityEngine;

public sealed class FranceAttack2Controller : MonoBehaviour
{
    [SerializeField]
    private CharaStatusData charaStatusData;

    // アニメーションの最後に呼び出す
    public void AnimationEnd()
    {
        this.transform.parent.gameObject.GetComponent<FranceController>().EndAttack2();
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var otherObject = other.gameObject;
        if (otherObject.tag == "Player" && !otherObject.transform.Equals(transform.parent) &&
            otherObject.TryGetComponent<PlayerController>(out var hitPlayer))
        {
            hitPlayer.OnDamage(charaStatusData.Attack2Power, charaStatusData.Attack2FreezingTime);
        }
    }
}
