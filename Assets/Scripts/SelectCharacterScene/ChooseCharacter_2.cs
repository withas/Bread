
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SelectCharacter
{
    public class ChooseCharacter_2 : MonoBehaviour
    {
        [SerializeField] GameObject gameManager;
        [SerializeField] GameManagerDate gameManagerDate;
        GameObject gameStartButton;
        public GameObject currentSelect;



        void Start()
        {
            gameManager = GameObject.Find("GameManager");

            //GameManagerDataを取得
            //ここが上手くいっていない
            // gameManagerDate = FindObjectOfType<GameManager>().GetGameManagerData();
            gameManagerDate = gameManager.GetComponent<GameManagerDate>();
            Debug.Log(gameManagerDate);
            //ボタンを取得
            gameStartButton = transform.parent.Find("ButtonPanel/GameStart").gameObject;
            //ボタンを無効にする
            gameStartButton.SetActive(false);
        }

        //キャラクターを選択した時に実行しキャラクターデータをMyGameManagerDataにセット
        public void OnSelectCharacter(GameObject character)
        {
            // Debug.Log(character.name);
            //ボタンの選択状態を解除して選択したボタンのハイライト表示を可能にする為に実行
            //マウス以外なら必要なし
            // EventSystem.current.SetSelectedGameObject(null);

            //　MyGameManagerDataにキャラクターデータをセットする
            gameManagerDate.SetCharacter_2(character);

            //GameStartButtonにプレイヤーが選択されたことを知らせる
            gameStartButton.GetComponent<GameStartButton>().ActivateButton(1);

            //表示用に現在選んでいるキャラを保存
            currentSelect = character;

            // //　ゲームスタートボタンを有効にする
            // gameStartButton.SetActive(true);
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