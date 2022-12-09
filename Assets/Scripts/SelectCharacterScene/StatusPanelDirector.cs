using UnityEngine;
using UnityEngine.UI;

public sealed class StatusPanelDirector : MonoBehaviour
{
    [SerializeField]
    private CharaPrefabsData charaPrefabsData;

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
        if (!charaPrefabsData.TryGetPrefab(character, out var playerController))
        {
            return;
        }

        // HP、Speed、Jumpスライダーの値を更新する
        hpSlider.value = playerController.GetMaxHp();
        speedSlider.value = playerController.GetSpeed();
        jumpSlider.value = playerController.GetJump();

        // Attack1のPowerを取得する
        var punchController = playerController.GetComponentInChildren<PunchController>();
        int attack1Power = punchController.GetPower();

        // Attack2のPowerを取得する
        int attack2Power = GetAttack2Power(character);

        // Attackスライダーに各攻撃力の平均値を設定する
        attackSlider.value = (attack1Power + attack2Power) / 2.0f;

        // Guardスライダーにガード率の逆数を設定する
        guardSlider.value = 1.0f / playerController.GetGuardingRatio();
    }

    private int GetAttack2Power(Characters character)
    {
        return character switch
        {
            Characters.Curry => charaPrefabsData.CurryAttack2Prefab.GetPower(),
            Characters.France => charaPrefabsData.FranceAttack2Prefab.GetPower(),
            Characters.Melon => charaPrefabsData.MelonAttack2Prefab.GetPower(),
            Characters.Cornet => charaPrefabsData.CornetAttack2Prefab.GetPower(),
            _ => 0,
        };
    }
}
