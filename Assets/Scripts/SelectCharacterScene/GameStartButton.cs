using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class GameStartButton : MonoBehaviour
{
    [SerializeField]
    private bool[] player = new bool[2];

    public void ActivateButton(int num)
    {
        player[num] = true;
        
        //プレイヤーが全てTrueならボタンを有効
        if (player.All(i => i))
        {
            gameObject.SetActive(true);
        }
    }

    public void OnGameStart()
    {
        SceneManager.LoadScene("BattleScene");
    }
}
