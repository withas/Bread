using UnityEngine;

/// <summary>
/// キャラクターの各パラメータのデータ
/// </summary>
[CreateAssetMenu(fileName = "CharaStatusData", menuName = "ScriptableObjects/CharaStatusData")]
public sealed class CharaStatusData : ScriptableObject
{
    [SerializeField]
    private int maxHP;

    public int MaxHP => maxHP;

    [SerializeField]
    private float moveSpeed;

    public float MoveSpeed => moveSpeed;

    [SerializeField]
    private float jumpForce;

    public float JumpForce => jumpForce;

    [SerializeField]
    private float guardingRatio;

    public float GuardingRatio => guardingRatio;

    [SerializeField]
    private int attack1Power;

    public int Attack1Power => attack1Power;

    [SerializeField]
    private float attack1FreezingTime;

    public float Attack1FreezingTime => attack1FreezingTime;

    [SerializeField]
    private int attack2Power;

    public int Attack2Power => attack2Power;

    [SerializeField]
    private float attack2FreezingTime;

    public float Attack2FreezingTime => attack2FreezingTime;
}
