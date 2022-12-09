using UnityEngine;

namespace SelectCharacter
{
    public sealed class GameStarter : MonoBehaviour
    {
        [SerializeField]
        GameManagerDate gameManagerData;

        [SerializeField]
        GameObject[] respownPos;

        public GameObject[] activeChara;

        private void Awake()
        {
            if (Screen.fullScreen)
            {
                Cursor.visible = false; // マウスカーソルを非表示にする
            }

            activeChara = new GameObject[2];
            respownPos[0] = transform.Find("PlayerRespown").gameObject;
            respownPos[1] = transform.Find("Player_2Respown").gameObject;

            // gameManagerData=FindObjectOfType<GameManager>().GetGameManagerData();
            gameManagerData = GameObject.Find("GameManager").GetComponent<GameManagerDate>();
            Debug.Log("Instantiate");

            //Playerを生成
            activeChara[0] = Instantiate(gameManagerData.GetCharacter(), respownPos[0].transform.position, Quaternion.identity);
            PlayerController player1Controller = activeChara[0].GetComponent<PlayerController>();
            player1Controller.SetPlayerNum(1);
            player1Controller.SetDirection(1.0f); // 右向きにする

            // キーボードで操作するオブジェクトを設定する
            GameObject.Find("KeyboardInput").GetComponent<KeyboardInputManager>().SetPlayer(activeChara[0]);

            activeChara[1] = Instantiate(gameManagerData.GetCharacter_2(), respownPos[1].transform.position, Quaternion.identity);
            PlayerController player2Controller = activeChara[1].GetComponent<PlayerController>();
            player2Controller.SetPlayerNum(2);
            player2Controller.SetDirection(-1.0f); // 左向きにする

            // ゲームパッドで操作するオブジェクトを設定する
            GameObject.Find("GamepadInput").GetComponent<GamepadInputManager>().SetPlayer(activeChara[1]);
        }
    }
}
