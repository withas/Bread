using UnityEngine;

public sealed class CharaButtonsDirector : MonoBehaviour
{
    [SerializeField]
    private GameObject curryButtonBg;

    [SerializeField]
    private GameObject franceButtonBg;

    [SerializeField]
    private GameObject melonButtonBg;

    [SerializeField]
    private GameObject cornetButtonBg;

    // 選択されているキャラクター
    private Characters selectedCharacter;

    public void SetBgActive(Characters character)
    {
        // 選択されていたキャラクターのボタンの背景を非表示にする
        if (TryGetBg(selectedCharacter, out var selectedCharaBg))
        {
            selectedCharaBg.SetActive(false);
        }

        // 選択されているキャラクターを更新する
        selectedCharacter = character;

        // 新しく選択されたキャラクターのボタンの背景を表示する
        if (TryGetBg(character, out var charaBg))
        {
            charaBg.SetActive(true);
        }
    }

    private bool TryGetBg(Characters character, out GameObject bg)
    {
        switch (character)
        {
            case Characters.Curry:
                bg = curryButtonBg;
                return true;
            case Characters.France:
                bg = franceButtonBg;
                return true;
            case Characters.Melon:
                bg = melonButtonBg;
                return true;
            case Characters.Cornet:
                bg = cornetButtonBg;
                return true;
            default:
                bg = null;
                return false;
        }
    }
}
