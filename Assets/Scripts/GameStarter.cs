using UnityEngine;
using Cysharp.Threading.Tasks;

namespace SelectCharacter
{
    public sealed class GameStarter : MonoBehaviour
    {
        [SerializeField]
        private CharaPrefabsData charaPrefabsData;

        [SerializeField]
        private CountDown countDown;

        [SerializeField]
        private Transform player1SpawnPoint;

        [SerializeField]
        private Transform player2SpawnPoint;

        public async UniTaskVoid StartGame(Characters player1Chara, Characters player2Chara)
        {
            if (Screen.fullScreen)
            {
                Cursor.visible = false; // マウスカーソルを非表示にする
            }

            if (!charaPrefabsData.TryGetPrefab(player1Chara, out var player1Prefab))
            {
                return;
            }

            //Playerを生成
            var player1Controller = Instantiate(player1Prefab, player1SpawnPoint.position, Quaternion.identity);
            player1Controller.SetPlayerNum(1);
            player1Controller.SetDirection(1.0f); // 右向きにする
            player1Controller.enabled = false;

            // キーボードで操作するオブジェクトを設定する
            GameObject.Find("KeyboardInput").GetComponent<KeyboardInputManager>().SetPlayer(player1Controller.gameObject);

            if (!charaPrefabsData.TryGetPrefab(player2Chara, out var player2Prefab))
            {
                return;
            }

            var player2Controller = Instantiate(player2Prefab, player2SpawnPoint.position, Quaternion.identity);
            player2Controller.SetPlayerNum(2);
            player2Controller.SetDirection(-1.0f); // 左向きにする
            player2Controller.enabled = false;

            // ゲームパッドで操作するオブジェクトを設定する
            GameObject.Find("GamepadInput").GetComponent<GamepadInputManager>().SetPlayer(player2Controller.gameObject);

            await countDown.CountDownAsync();

            player1Controller.enabled = true;
            player2Controller.enabled = true;
        }
    }
}
