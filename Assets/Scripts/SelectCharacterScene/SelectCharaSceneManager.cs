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
    private Button gameStartButton;

    [SerializeField]
    private string battleSceneName;

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

        gameStartButton.OnClickAsObservable()
                       .Subscribe(_ => OnStartButtonClicked().Forget());
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

    private async UniTaskVoid OnStartButtonClicked()
    {
        await SceneManager.LoadSceneAsync(battleSceneName);

        if (!TryGetComponentInScene<SelectCharacter.GameStarter>(battleSceneName, out var gameStarter))
        {
            return;
        }

        gameStarter.StartGame(player1Character, player2Character).Forget();
    }

    private bool TryGetComponentInScene<TComponent>(string sceneName, out TComponent component) where TComponent : Component
    {
        var scene = SceneManager.GetSceneByName(battleSceneName);

        var gameObjects = scene.GetRootGameObjects();

        foreach (var gameObject in gameObjects)
        {
            component = gameObject.GetComponentInChildren<TComponent>();
            if (component != null)
            {
                return true;
            }
        }

        component = null;
        return false;
    }
}
