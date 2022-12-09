using UnityEngine;
using UnityEngine.UI;

public class DisplayCharaDirector : MonoBehaviour
{
    [SerializeField]
    private Sprite curryKeyVisual;

    [SerializeField]
    private Sprite franceKeyVisual;

    [SerializeField]
    private Sprite melonKeyVisual;

    [SerializeField]
    private Sprite cornetKeyVisual;

    [SerializeField]
    private Image keyVisualImage;

    [SerializeField]
    private Text charaNameFrontText;

    [SerializeField]
    private Text charaNameBackText;

    public void Display(Characters character)
    {
        switch (character)
        {
            case Characters.Curry:
                charaNameFrontText.text = charaNameBackText.text = "カレーパン";
                keyVisualImage.sprite = curryKeyVisual;
                break;
            case Characters.France:
                charaNameFrontText.text = charaNameBackText.text = "フランスパン";
                keyVisualImage.sprite = franceKeyVisual;
                break;
            case Characters.Melon:
                charaNameFrontText.text = charaNameBackText.text = "メロンパン";
                keyVisualImage.sprite = melonKeyVisual;
                break;
            case Characters.Cornet:
                charaNameFrontText.text = charaNameBackText.text = "チョココロネ";
                keyVisualImage.sprite = cornetKeyVisual;
                break;
            default:
                charaNameFrontText.text = charaNameBackText.text = "";
                keyVisualImage.sprite = null;
                break;
        }
    }
}
