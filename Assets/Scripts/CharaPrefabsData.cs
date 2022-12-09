using UnityEngine;

[CreateAssetMenu(fileName = "CharaPrefabsData", menuName = "ScriptableObjects/CreateCharaPrefabsData")]
public sealed class CharaPrefabsData : ScriptableObject
{
    [SerializeField]
    private CurryController curryPrefab;

    public CurryController CurryPrefab => curryPrefab;

    [SerializeField]
    private CurryAttack2Controller curryAttack2Prefab;

    public CurryAttack2Controller CurryAttack2Prefab => curryAttack2Prefab;

    [SerializeField]
    private FranceController francePrefab;

    public FranceController FrancePrefab => francePrefab;

    [SerializeField]
    private FranceAttack2Controller franceAttack2Prefab;

    public FranceAttack2Controller FranceAttack2Prefab => franceAttack2Prefab;

    [SerializeField]
    private MelonController melonPrefab;

    public MelonController MelonPrefab => melonPrefab;

    [SerializeField]
    private MelonAttack2Controller melonAttack2Prefab;

    public MelonAttack2Controller MelonAttack2Prefab => melonAttack2Prefab;

    [SerializeField]
    private CornetController cornetPrefab;

    public CornetController CornetPrefab => cornetPrefab;

    [SerializeField]
    private CornetAttack2Controller cornetAttack2Prefab;

    public CornetAttack2Controller CornetAttack2Prefab => cornetAttack2Prefab;
}
