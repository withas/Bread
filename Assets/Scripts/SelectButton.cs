using UnityEngine;
using UnityEngine.UI;

public sealed class SelectButton : MonoBehaviour
{
    [SerializeField]
    Button button;

    private void Start()
    {
        // button = GameObject.Find("Canvas/ButtonSummary/Button").GetComponent<Button>();
        // ボタンが選択された状態になる
        button.Select();
    }
}
