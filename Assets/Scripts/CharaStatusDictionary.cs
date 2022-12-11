using UnityEngine;

/// <summary>
/// キャラクターと各パラメータのデータを対応付けるデータ
/// </summary>
[CreateAssetMenu(fileName = "CharaStatusDictionary", menuName = "ScriptableObjects/CharaStatusDictionary")]
public sealed class CharaStatusDictionary : ScriptableObject
{
    [SerializeField]
    private CharaStatusData curryStatusData;

    public CharaStatusData CurryStatusData => curryStatusData;

    [SerializeField]
    private CharaStatusData franceStatusData;

    public CharaStatusData FranceStatusData => franceStatusData;

    [SerializeField]
    private CharaStatusData melonStatusData;

    public CharaStatusData MelonStatusData => melonStatusData;

    [SerializeField]
    private CharaStatusData cornetStatusData;

    public CharaStatusData CornetStatusData => cornetStatusData;

    public bool TryGetStatusData(Characters character, out CharaStatusData statusData)
    {
        switch (character)
        {
            case Characters.Curry:
                statusData = curryStatusData;
                return true;
            case Characters.France:
                statusData = franceStatusData;
                return true;
            case Characters.Melon:
                statusData = melonStatusData;
                return true;
            case Characters.Cornet:
                statusData = cornetStatusData;
                return true;
            default:
                statusData = null;
                return false;
        }
    }
}
