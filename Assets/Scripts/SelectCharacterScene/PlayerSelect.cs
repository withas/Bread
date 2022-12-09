using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using SelectCharacter;

public class PlayerSelect : MonoBehaviour
{
    [SerializeField] GameManagerDate gameManagerDate;
    private void Start() {
        gameManagerDate = GameObject.FindObjectOfType<GameManagerDate>();
        this.gameObject.SetActive(false);
    }

    public void ActivateButton(int array)
    {

        gameManagerDate.SetPlayerisReady(array);
        
        //プレイヤーが全てTrueならボタンを有効
        if(gameManagerDate.GetPlayerisReady())
        {
            SceneManager.LoadScene("BattleScene");
        }

        // if(player[0] && player[1])
        // {
        //     gameObject.SetActive(true);
        // }
        
    }
}

//     public void OnGameStart() {
        
//     }
// }
