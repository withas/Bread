using UnityEngine;

namespace SelectCharacter
{
    public class GameManagerDate : MonoBehaviour
    {
        [SerializeField]
        private GameObject character;

        [SerializeField]
        private GameObject character_2;

        [SerializeField]
        private int winnerPlayerNum;

        private bool[] isReady = new bool[2];

        public void SetCharacter(GameObject character)
        {
            this.character = character;
        }

        public void SetCharacter_2(GameObject character_2)
        {
            this.character_2 = character_2;
        }

        public void SetWinnerPlayerNum(int num)
        {
            this.winnerPlayerNum = num;
        }

        public GameObject GetCharacter()
        {
            return character;
        }

        public GameObject GetCharacter_2()
        {
            return character_2;
        }

        public int GetWinnerPlayerNum()
        {
            return winnerPlayerNum;
        }

        public void SetPlayerisReady(int b)
        {
            isReady[b] = true;
        }

        public bool GetPlayerisReady()
        {
            if (isReady[0] && isReady[1])
            {
                isReady[0] = false;
                isReady[1] = false;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
