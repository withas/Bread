using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

public class CountDown : MonoBehaviour
{
    [SerializeField]
    private Text textCountdown;

    [SerializeField]
    private AudioSource audioSource;

    //開始のコング
    [SerializeField]
    private AudioClip startSE;

    [SerializeField]
    private int countDownNum = 3;

    public async UniTask CountDownAsync()
    {
        textCountdown.gameObject.SetActive(true);

        // カウントダウン開始
        while (countDownNum > 0)
        {
            textCountdown.text = countDownNum.ToString("F0");

            await UniTask.Delay(1000);

            countDownNum--;
        }

        textCountdown.text = "GO!";
        audioSource.PlayOneShot(startSE);

        await UniTask.Delay(1000);

        textCountdown.text = "";
        textCountdown.gameObject.SetActive(false);
    }
}
