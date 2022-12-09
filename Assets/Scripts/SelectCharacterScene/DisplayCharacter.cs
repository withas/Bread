using UnityEngine;
using UnityEngine.UI;

public sealed class DisplayCharacter : MonoBehaviour
{
    [SerializeField]
    Sprite[] charaImg;

    Image nowImg;

    [SerializeField]
    GameObject selectCharactorPanel;

    SelectCharacter.ChooseCharacter cchara;
 
    private void Start()
    {
        cchara = selectCharactorPanel.GetComponent<SelectCharacter.ChooseCharacter>();

        nowImg = transform.Find("Image").GetComponent<Image>();
    }

    private void Update()
    {
        // Debug.Log(nowImg);
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
