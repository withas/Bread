using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UniRx;
using Cysharp.Threading.Tasks;

public sealed class ResultSceneManager : MonoBehaviour
{
    [SerializeField]
    private Image player1Image;

    [SerializeField]
    private Image player2Image;

    [SerializeField]
    private Text player1FrontText;

    [SerializeField]
    private Text player1BackText;

    [SerializeField]
    private Text player2FrontText;

    [SerializeField]
    private Text player2BackText;

    [SerializeField]
    private Button charaSelectButton;

    [SerializeField]
    private Button retryButton;

    [SerializeField]
    private CharaSpriteData winnerSpriteData;

    [SerializeField]
    private CharaSpriteData loserSpriteData;

    [SerializeField]
    private string charaSelectSceneName;

    [SerializeField]
    private string battleSceneName;

    private CharaSelectData charaSelectData;

    public void ShowResult(CharaSelectData charaSelectData, int winnerNumber)
    {
        this.charaSelectData = charaSelectData;

        charaSelectButton.OnClickAsObservable()
                         .Subscribe(_ => OnCharaSelectButtonClicked())
                         .AddTo(this);

        retryButton.OnClickAsObservable()
                   .Subscribe(_ => OnRetrySelected().Forget())
                   .AddTo(this);

        if (winnerNumber == 0)
        {
            if (winnerSpriteData.TryGetSprite(charaSelectData.Player1Chara, out var winnerSprite))
            {
                player1Image.sprite = winnerSprite;
            }
            player1FrontText.text = player1BackText.text = "WIN";

            if (loserSpriteData.TryGetSprite(charaSelectData.Player2Chara, out var loserSprite))
            {
                player2Image.sprite = loserSprite;
            }
            player2FrontText.text = player2BackText.text = "LOSE";
        }
        else if (winnerNumber == 1)
        {
            if (winnerSpriteData.TryGetSprite(charaSelectData.Player2Chara, out var winnerSprite))
            {
                player2Image.sprite = winnerSprite;
            }
            player2FrontText.text = player2BackText.text = "WIN";

            if (loserSpriteData.TryGetSprite(charaSelectData.Player1Chara, out var loserSprite))
            {
                player1Image.sprite = loserSprite;
            }
            player1FrontText.text = player1BackText.text = "LOSE";
        }
    }

    private void OnCharaSelectButtonClicked()
    {
        SceneManager.LoadScene(charaSelectSceneName);
    }

    private async UniTaskVoid OnRetrySelected()
    {
        await SceneManager.LoadSceneAsync(battleSceneName);

        if (!SceneManagerExtension.TryGetComponentInScene<GameStarter>(battleSceneName, out var gameStarter))
        {
            return;
        }

        gameStarter.StartAsync(charaSelectData).Forget();
    }
}
