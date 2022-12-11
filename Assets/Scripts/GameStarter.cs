using UnityEngine;
using Cysharp.Threading.Tasks;
using UniRx;

namespace SelectCharacter
{
    public sealed class GameStarter : MonoBehaviour
    {
        [SerializeField]
        private CharaPrefabsData charaPrefabsData;

        [SerializeField]
        private CountDown countDown;

        [SerializeField]
        private BattleFinish battleFinish;

        [SerializeField]
        private Transform player1SpawnPoint;

        [SerializeField]
        private Transform player2SpawnPoint;

        public async UniTaskVoid StartGame(CharaSelectData charaSelectData)
        {
            if (Screen.fullScreen)
            {
                Cursor.visible = false; // マウスカーソルを非表示にする
            }

            battleFinish.SetCharacters(charaSelectData);

            if (!charaPrefabsData.TryGetPrefab(charaSelectData.Player1Chara, out var player1Prefab))
            {
                return;
            }

            //Playerを生成
            var player1Controller = Instantiate(player1Prefab, player1SpawnPoint.position, Quaternion.identity);
            player1Controller.SetPlayerNum(1);
            player1Controller.SetDirection(1.0f); // 右向きにする
            player1Controller.enabled = false;

            player1Controller.OnDownedObservable
                             .Subscribe(_ => battleFinish.OnFinish(1).Forget())
                             .AddTo(battleFinish);

            if (!charaPrefabsData.TryGetPrefab(charaSelectData.Player2Chara, out var player2Prefab))
            {
                return;
            }

            var player2Controller = Instantiate(player2Prefab, player2SpawnPoint.position, Quaternion.identity);
            player2Controller.SetPlayerNum(2);
            player2Controller.SetDirection(-1.0f); // 左向きにする
            player2Controller.enabled = false;

            player2Controller.OnDownedObservable
                             .Subscribe(_ => battleFinish.OnFinish(0).Forget())
                             .AddTo(battleFinish);

            await countDown.CountDownAsync();

            player1Controller.enabled = true;
            player2Controller.enabled = true;
        }
    }
}
