using UnityEngine;
using Cysharp.Threading.Tasks;
using UniRx;

public sealed class GameStarter : MonoBehaviour
{
    [SerializeField]
    private CharaPrefabsDictionary charaPrefabsDictionary;

    [SerializeField]
    private CountDown countDown;

    [SerializeField]
    private BattleFinisher battleFinisher;

    [SerializeField]
    private Transform player1SpawnPoint;

    [SerializeField]
    private Transform player2SpawnPoint;

    public async UniTaskVoid StartAsync(CharaSelectData charaSelectData)
    {
        if (Screen.fullScreen)
        {
            Cursor.visible = false; // マウスカーソルを非表示にする
        }

        battleFinisher.SetCharacters(charaSelectData);

        // Player1を生成
        if (!charaPrefabsDictionary.TryGetPrefab(charaSelectData.Player1Chara, out var player1Prefab))
        {
            return;
        }

        var player1Controller = Instantiate(player1Prefab, player1SpawnPoint.position, Quaternion.identity);
        if (!PlayerInputManagerHelper.Instance.TryGetPlayerInput(0, out var player1Input))
        {
            return;
        }
        player1Controller.SetPlayerInput(player1Input);
        player1Controller.SetPlayerNum(1);
        player1Controller.SetDirection(1.0f); // 右向きにする
        player1Controller.enabled = false;

        player1Controller.OnDownedObservable
                         .Subscribe(_ => battleFinisher.FinishAsync(1).Forget())
                         .AddTo(battleFinisher);

        // Player2を生成
        if (!charaPrefabsDictionary.TryGetPrefab(charaSelectData.Player2Chara, out var player2Prefab))
        {
            return;
        }

        var player2Controller = Instantiate(player2Prefab, player2SpawnPoint.position, Quaternion.identity);
        if (!PlayerInputManagerHelper.Instance.TryGetPlayerInput(1, out var player2Input))
        {
            return;
        }
        player2Controller.SetPlayerInput(player2Input);
        player2Controller.SetPlayerNum(2);
        player2Controller.SetDirection(-1.0f); // 左向きにする
        player2Controller.enabled = false;

        player2Controller.OnDownedObservable
                         .Subscribe(_ => battleFinisher.FinishAsync(0).Forget())
                         .AddTo(battleFinisher);

        await countDown.CountDownAsync();

        player1Controller.enabled = true;
        player2Controller.enabled = true;
    }
}
