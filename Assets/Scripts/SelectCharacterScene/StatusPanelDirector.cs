using UnityEngine;
using UnityEngine.UI;

public sealed class StatusPanelDirector : MonoBehaviour
{
    [SerializeField]
    private CharaStatusDictionary charaStatusDictionary;

    [SerializeField]
    private Slider hpSlider;

    [SerializeField]
    private Slider attackSlider;

    [SerializeField]
    private Slider speedSlider;

    [SerializeField]
    private Slider jumpSlider;

    [SerializeField]
    private Slider guardSlider;

    public void SetStatus(Characters character)
    {
        // キャラクターのPrefabを取得する
        if (!charaStatusDictionary.TryGetStatusData(character, out var statusData))
        {
            return;
        }

        // HP、Speed、Jumpスライダーの値を更新する
        hpSlider.value = statusData.MaxHP;
        speedSlider.value = statusData.MoveSpeed;
        jumpSlider.value = statusData.JumpForce;

        // Attackスライダーに各攻撃の威力の平均値を設定する
        attackSlider.value = (statusData.Attack1Power + statusData.Attack2Power) / 2.0f;

        // Guardスライダーにガード率の逆数を設定する
        guardSlider.value = 1.0f / statusData.GuardingRatio;
    }
}
