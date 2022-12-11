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

    private CharaSelectData charaSelectData;

    public void SetCharacters(CharaSelectData charaSelectData)
    {
        this.charaSelectData = charaSelectData;
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
            resultSceneManager.ShowResult(charaSelectData, playerNumber);
        }
    }
}
