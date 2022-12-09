using UnityEngine;
using UnityEngine.UI;

public sealed class DisplayCharacter : MonoBehaviour
{
    [SerializeField]
    private Sprite[] charaImg;

    private Image nowImg;

    [SerializeField]
    private GameObject selectCharactorPanel;

    private SelectCharacter.ChooseCharacter cchara;

    private void Start()
    {
        cchara = selectCharactorPanel.GetComponent<SelectCharacter.ChooseCharacter>();

        nowImg = transform.Find("Image").GetComponent<Image>();
    }

    private void Update()
    {
        if (cchara.currentSelect)
        {
            Show();
        }
    }

    private void Show()
    {
        switch (cchara.currentSelect.name)
        {
            case "Curry":
                nowImg.sprite = charaImg[0];
                break;
            case "France":
                nowImg.sprite = charaImg[1];
                break;
            case "Melon":
                nowImg.sprite = charaImg[2];
                break;
            case "Cornet":
                nowImg.sprite = charaImg[3];
                break;
        }
    }
}
