using UnityEngine;
using UnityEngine.UI;
using UniRx;

public sealed class SelectCharaSceneManager : MonoBehaviour
{
    [SerializeField]
    private SelectCharaPanelDirector selectCharaPanelDirector1;

    [SerializeField]
    private SelectCharaPanelDirector selectCharaPanelDirector2;

    [SerializeField]
    private Button gameStartButton;

    private Characters player1Character;

    private bool player1Selected = false;

    private Characters player2Character;

    private bool player2Selected = false;

    private void Start()
    {
        selectCharaPanelDirector1.GetCharaSelectedObservable()
                                 .Subscribe(c => OnCharaSelected(0, c));

        selectCharaPanelDirector2.GetCharaSelectedObservable()
                                 .Subscribe(c => OnCharaSelected(1, c));
    }

    private void OnCharaSelected(int playerNumber, Characters character)
    {
        switch (playerNumber)
        {
            case 0:
                player1Character = character;
                player1Selected = true;
                break;
            case 1:
                player2Character = character;
                player2Selected = true;
                break;
            default:
                break;
        }

        if (player1Selected && player2Selected)
        {
            gameStartButton.gameObject.SetActive(true);
        }
    }
}
