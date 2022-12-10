using UnityEngine;
using UnityEngine.UI;

namespace SelectCharacter
{
    public sealed class ResultSceneManager : MonoBehaviour
    {
        [SerializeField]
        private GameManagerDate gameManagerData;

        [SerializeField]
        private int winnerPlayerNum;

        [SerializeField]
        private Text P1_text;

        [SerializeField]
        private Text P2_text;

        [SerializeField]
        private Transform[] playerPos;

        [SerializeField]
        private Sprite[] winner;

        [SerializeField]
        private Sprite[] loser;

        private Image[] player;

        private void Start()
        {
            player = new Image[playerPos.Length];
            player[0] = GameObject.Find("Player1").gameObject.GetComponent<Image>();
            player[1] = GameObject.Find("Player2").gameObject.GetComponent<Image>();

            gameManagerData = GameObject.Find("GameManager").GetComponent<GameManagerDate>();
            winnerPlayerNum = gameManagerData.GetWinnerPlayerNum();

            //プレイヤー1の勝ち
            if (winnerPlayerNum == 1)
            {
                switch (gameManagerData.GetCharacter().gameObject.name)
                {
                    case "Curry":
                        player[0].sprite = winner[1];
                        break;
                    case "France":
                        player[0].sprite = winner[2];
                        break;
                    case "Melon":
                        player[0].sprite = winner[3];
                        break;
                    case "Cornet":
                        player[0].sprite = winner[4];
                        break;
                    default:
                        player[0].sprite = winner[0];
                        break;
                }
                switch (gameManagerData.GetCharacter_2().gameObject.name)
                {
                    case "Curry":
                        player[1].sprite = loser[1];
                        break;
                    case "France":
                        player[1].sprite = loser[2];
                        break;
                    case "Melon":
                        player[1].sprite = loser[3];
                        break;
                    case "Cornet":
                        player[1].sprite = loser[4];
                        break;
                    default:
                        player[1].sprite = loser[0];
                        break;
                }
                P1_text.text = "WIN";
                P1_text.transform.Find("Result").GetComponent<Text>().text = "WIN";
                P2_text.text = "LOSE";
                P2_text.transform.Find("Result").GetComponent<Text>().text = "LOSE";
            }

            //プレイヤー２が勝ち
            if (winnerPlayerNum == 2)
            {
                switch (gameManagerData.GetCharacter_2().gameObject.name)
                {
                    case "Curry":
                        player[1].sprite = winner[1];
                        break;
                    case "France":
                        player[1].sprite = winner[2];
                        break;
                    case "Melon":
                        player[1].sprite = winner[3];
                        break;
                    case "Cornet":
                        player[1].sprite = winner[4];
                        break;
                    default:
                        player[1].sprite = winner[0];
                        break;
                }
                switch (gameManagerData.GetCharacter().gameObject.name)
                {
                    case "Curry":
                        player[0].sprite = loser[1];
                        break;
                    case "France":
                        player[0].sprite = loser[2];
                        break;
                    case "Melon":
                        player[0].sprite = loser[3];
                        break;
                    case "Cornet":
                        player[0].sprite = loser[4];
                        break;
                    default:
                        player[0].sprite = loser[0];
                        break;
                }
                P1_text.text = "LOSE";
                P1_text.transform.Find("Result").GetComponent<Text>().text = "LOSE";
                P2_text.text = "WIN";
                P2_text.transform.Find("Result").GetComponent<Text>().text = "WIN";
            }
        }
    }
}
