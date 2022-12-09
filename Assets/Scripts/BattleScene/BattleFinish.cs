using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using SelectCharacter;

public class BattleFinish : MonoBehaviour
{
    [SerializeField] GameManagerDate gameManagerData;
    [SerializeField] GameObject text;

    //終了のコング
    [SerializeField] AudioClip finishSE;
    AudioSource audioSource;

    private void Start()
    {
        gameManagerData = GameObject.Find("GameManager").GetComponent<GameManagerDate>();

        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void Finish(int playerNum)
    {
        Cursor.visible = true; // マウスカーソルを表示する

        //勝った相手のNumを入れる
        switch (playerNum)
        {
            case 1:
                gameManagerData.SetWinnerPlayerNum(2);
                break;
            case 2:
                gameManagerData.SetWinnerPlayerNum(1);
                break;
        }
        StartCoroutine(LoadResult());
    }

    IEnumerator LoadResult()
    {
        text.SetActive(true);
        audioSource.PlayOneShot(finishSE);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Result");
    }
}
