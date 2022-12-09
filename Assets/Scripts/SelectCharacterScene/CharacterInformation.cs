using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInformation : MonoBehaviour
{
    [SerializeField] GameObject selectPlayerPanel;
    [SerializeField] SelectCharacter.ChooseCharacter cchara;

    // Animation animation;
    SpriteRenderer spriteRenderer;
    [SerializeField] Text charaName;
    [SerializeField] Text explanation;
    [SerializeField] GameObject CharaAnim;

    private void Start()
    {
        cchara = selectPlayerPanel.GetComponent<SelectCharacter.ChooseCharacter>();
    }

    public void Update()
    {
        if (!cchara.currentSelect) return;

        switch (cchara.currentSelect.name)
        {
            case "Curry":
                charaName.text = "カレーパン";
                charaName.transform.Find("Text").GetComponent<Text>().text = "カレーパン";
                explanation.text = "テスト";
                break;
            case "France":
                charaName.text = "フランスパン";
                charaName.transform.Find("Text").GetComponent<Text>().text = "フランスパン";
                explanation.text = "テスト";
                break;
            case "Melon":
                charaName.text = "メロンパン";
                charaName.transform.Find("Text").GetComponent<Text>().text = "メロンパン";
                explanation.text = "テスト";
                break;
            case "Cornet":
                charaName.text = "チョココロネ";
                charaName.transform.Find("Text").GetComponent<Text>().text = "チョココロネ";
                explanation.text = "テスト";
                break;
        }

    }
}
