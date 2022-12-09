using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class ResultButton : MonoBehaviour
{   
    public void GotoSelect()
    {
        SceneManager.LoadScene("Select");
    }

    public void RetryBattle()
    {
        SceneManager.LoadScene("BattleScene");
    }
}
