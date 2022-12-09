using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SelectCharacter;

public class CountDown : MonoBehaviour
{
    [SerializeField] Text textCountdown;
    [SerializeField] int CountDownNum = 3;
    [SerializeField] GameObject[] player;
    GameStart gameStart;

    //開始のコング
    [SerializeField] AudioClip startSE;
    AudioSource audioSource;

    // private GameManagerDate gameManagerData;  //キャラクターを保存しているデータ


    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        gameStart = FindObjectOfType<GameStart>();

        player = new GameObject[2];
        // gameManagerData = GameObject.Find("GameManager").GetComponent<GameManagerDate>();
        player[0] = gameStart.activeChara[0];
        player[1] = gameStart.activeChara[1];


        // //テスト用
        // if(player[0] == null) 
        // {
        //     player[0] = GameObject.Find("Player1");
        //     player[0].SetActive(true);
        // }
        // //ここまでテスト用

        textCountdown.text = "";
        foreach (var p in player)
        {
            p.GetComponent<PlayerController>().enabled = false;
        }

        StartCoroutine(CountdownCoroutine());
    }

    IEnumerator CountdownCoroutine()
    {
        textCountdown.gameObject.SetActive(true);


        // textCountdown.text = "3";
        // yield return new WaitForSeconds(1.0f);

        // textCountdown.text = "2";
        // yield return new WaitForSeconds(1.0f);

        // textCountdown.text = "1";
        // yield return new WaitForSeconds(1.0f);

        //カウントダウン開始
        while (CountDownNum > 0)
        {
            textCountdown.text = CountDownNum.ToString("F0");
            yield return new WaitForSeconds(1.0f);
            CountDownNum--;
        }
        textCountdown.text = "GO!";
        audioSource.PlayOneShot(startSE);
        yield return new WaitForSeconds(1.0f);

        textCountdown.text = "";
        textCountdown.gameObject.SetActive(false);

        foreach (var p in player)
        {
            p.GetComponent<PlayerController>().enabled = true;
        }
    }
}
