using UnityEngine;

namespace SelectCharacter
{
    public sealed class ChooseCharacter : MonoBehaviour
    {
        [SerializeField]
        private GameObject gameManager;

        [SerializeField]
        private GameManagerDate gameManagerDate;

        [SerializeField]
        private GameObject gameStartButton;

        public GameObject currentSelect;

        [SerializeField]
        private int buttonNum = 0;

        private void Start()
        {
            gameManager = GameObject.Find("GameManager");

            if (!gameStartButton)
            {
                return;
            }

            //ボタンを無効にする
            gameStartButton.SetActive(false);
        }

        //キャラクターを選択した時に実行しキャラクターデータをMyGameManagerDataにセット
        public void OnSelectCharacter(GameObject character)
        {
            //　MyGameManagerDataにキャラクターデータをセットする
            if (buttonNum == 0)
            {
                gameManagerDate.SetCharacter(character);
            }
            else if (buttonNum == 1)
            {
                gameManagerDate.SetCharacter_2(character);
            }

            //表示用に現在選んでいるキャラを保存
            currentSelect = character;

            if (!gameStartButton)
            {
                return;
            }

            //GameStartButtonにプレイヤーが選択されたことを知らせる
            gameStartButton.GetComponent<GameStartButton>().ActivateButton(buttonNum);
        }

        //　キャラクターを選択した時に背景をオンにする
        public void SwitchButtonBackground(int buttonNumber)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (i == buttonNumber - 1)
                {
                    transform.GetChild(i).Find("Background").gameObject.SetActive(true);
                }
                else
                {
                    transform.GetChild(i).Find("Background").gameObject.SetActive(false);
                }
            }
        }
    }
}
