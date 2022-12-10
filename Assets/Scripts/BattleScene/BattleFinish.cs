using UnityEngine;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;
using SelectCharacter;

public sealed class BattleFinish : MonoBehaviour
{
    [SerializeField]
    private GameObject text;

    //終了のコング
    [SerializeField]
    private AudioClip finishSE;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private string resultSceneName;

    private Characters player1Chara;

    private Characters player2Chara;

    public void SetCharacters(Characters player1Chara, Characters player2Chara)
    {
        this.player1Chara = player1Chara;
        this.player2Chara = player2Chara;
    }

    public async UniTaskVoid OnFinish(int playerNumber)
    {
        Cursor.visible = true; // マウスカーソルを表示する

        text.SetActive(true);
        audioSource.PlayOneShot(finishSE);

        await UniTask.Delay(2000);

        await SceneManager.LoadSceneAsync(resultSceneName);

        if (SceneManagerExtension.TryGetComponentInScene<ResultSceneManager>(resultSceneName, out var resultSceneManager))
        {
            resultSceneManager.ShowResult(player1Chara, player2Chara, playerNumber);
        }
    }
}
