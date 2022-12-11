using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UniRx;
using Cysharp.Threading.Tasks;

public sealed class SelectCharaSceneManager : MonoBehaviour
{
    [SerializeField]
    private SelectCharaPanelDirector selectCharaPanelDirector1;

    [SerializeField]
    private SelectCharaPanelDirector selectCharaPanelDirector2;

    [SerializeField]
    private string battleSceneName;

    private Characters player1Character;

    private bool player1Selected = false;

    private Characters player2Character;

    private bool player2Selected = false;

    private void Start()
    {
        selectCharaPanelDirector1.GetSelectedObservable()
                                 .Subscribe(c => OnCharaSelected(0, c))
                                 .AddTo(this);

        selectCharaPanelDirector2.GetSelectedObservable()
                                 .Subscribe(c => OnCharaSelected(1, c))
                                 .AddTo(this);
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
            LoadBattleSceneAsync().Forget();
        }
    }

    private async UniTaskVoid LoadBattleSceneAsync()
    {
        await SceneManager.LoadSceneAsync(battleSceneName);

        if (!SceneManagerExtension.TryGetComponentInScene<SelectCharacter.GameStarter>(battleSceneName, out var gameStarter))
        {
            return;
        }

        var charaSelectData = new CharaSelectData(player1Character, player2Character);

        gameStarter.StartGame(charaSelectData).Forget();
    }
}
