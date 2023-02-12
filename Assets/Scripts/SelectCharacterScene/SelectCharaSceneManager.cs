using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UniRx;
using Cysharp.Threading.Tasks;

public sealed class SelectCharaSceneManager : MonoBehaviour
{
    [SerializeField]
    private PlayerInputManager playerInputManager;

    [SerializeField]
    private SelectCharaCanvas SelectCharaCanvasPrefab;

    [SerializeField]
    private Text player1Text;

    [SerializeField]
    private Text player2Text;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip jingleClip;

    [SerializeField]
    private Fade fade;

    [SerializeField]
    private string battleSceneName;

    private Characters player1Character;

    private bool player1Selected = false;

    private Characters player2Character;

    private bool player2Selected = false;

    private void OnEnable()
    {
        playerInputManager.onPlayerJoined += OnPlayerJoined;
    }

    private void OnDisable()
    {
        playerInputManager.onPlayerJoined -= OnPlayerJoined;
    }

    private void OnPlayerJoined(PlayerInput playerInput)
    {
        // キャラクター選択のCanvasを生成する
        var selectCharaCanvas = Instantiate(SelectCharaCanvasPrefab);

        selectCharaCanvas.SelectCharaPanelDirector.SetPlayerIndex(playerInput.playerIndex);

        selectCharaCanvas.SelectCharaPanelDirector.GetSelectedObservable()
                                                  .Subscribe(c => OnCharaSelected(playerInput.playerIndex, c))
                                                  .AddTo(this);

        playerInput.uiInputModule = selectCharaCanvas.UIInputModule;

        if (playerInput.playerIndex == 0)
        {
            player1Text.gameObject.SetActive(false);
            player2Text.gameObject.SetActive(true);
        }
        else if (playerInput.playerIndex >= 1)
        {
            player2Text.gameObject.SetActive(false);

            // プレイヤーが2人になったら参加できなくする
            playerInputManager.DisableJoining();
        }
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
        // ジングルを再生する
        audioSource.Stop();
        audioSource.clip = jingleClip;
        audioSource.loop = false;
        audioSource.Play();

        await UniTask.Delay(4000);

        await fade.FadeIn(1.0f);

        await SceneManager.LoadSceneAsync(battleSceneName);

        if (!SceneManagerExtension.TryGetComponentInScene<SelectCharacter.GameStarter>(battleSceneName, out var gameStarter))
        {
            return;
        }

        var charaSelectData = new CharaSelectData(player1Character, player2Character);

        gameStarter.StartGame(charaSelectData).Forget();
    }
}
