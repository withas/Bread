using UnityEngine;

/// <summary>
/// キャラクターとSpriteを対応付けるデータ
/// </summary>
[CreateAssetMenu(fileName = "CharaSpriteData", menuName = "ScriptableObjects/CreateCharaSpriteData")]
public sealed class CharaSpriteData : ScriptableObject
{
    [SerializeField]
    private Sprite currySprite;

    public Sprite CurrySprite => currySprite;

    [SerializeField]
    private Sprite franceSprite;

    public Sprite FranceSprite => franceSprite;

    [SerializeField]
    private Sprite melonSprite;

    public Sprite MelonSprite => melonSprite;

    [SerializeField]
    private Sprite cornetSprite;

    public Sprite CornetSprite => cornetSprite;

    public bool TryGetSprite(Characters character, out Sprite sprite)
    {
        switch (character)
        {
            case Characters.Curry:
                sprite = currySprite;
                return true;
            case Characters.France:
                sprite = franceSprite;
                return true;
            case Characters.Melon:
                sprite = melonSprite;
                return true;
            case Characters.Cornet:
                sprite = cornetSprite;
                return true;
            default:
                sprite = null;
                return false;
        }
    }
}
