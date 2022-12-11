using UnityEngine;
using UnityEngine.UI;

namespace SelectCharacter
{
    public sealed class ResultSceneManager : MonoBehaviour
    {
        [SerializeField]
        private Image player1Image;

        [SerializeField]
        private Image player2Image;

        [SerializeField]
        private Text player1FrontText;

        [SerializeField]
        private Text player1BackText;

        [SerializeField]
        private Text player2FrontText;

        [SerializeField]
        private Text player2BackText;

        [SerializeField]
        private CharaSpriteData winnerSpriteData;

        [SerializeField]
        private CharaSpriteData loserSpriteData;

        private CharaSelectData charaSelectData;

        public void ShowResult(CharaSelectData charaSelectData, int winnerNumber)
        {
            this.charaSelectData = charaSelectData;

            if (winnerNumber == 0)
            {
                if (winnerSpriteData.TryGetSprite(charaSelectData.Player1Chara, out var winnerSprite))
                {
                    player1Image.sprite = winnerSprite;
                }
                player1FrontText.text = player1BackText.text = "WIN";

                if (loserSpriteData.TryGetSprite(charaSelectData.Player2Chara, out var loserSprite))
                {
                    player2Image.sprite = loserSprite;
                }
                player2FrontText.text = player2BackText.text = "LOSE";
            }
            else if (winnerNumber == 1)
            {
                if (winnerSpriteData.TryGetSprite(charaSelectData.Player2Chara, out var winnerSprite))
                {
                    player2Image.sprite = winnerSprite;
                }
                player2FrontText.text = player2BackText.text = "WIN";

                if (loserSpriteData.TryGetSprite(charaSelectData.Player1Chara, out var loserSprite))
                {
                    player1Image.sprite = loserSprite;
                }
                player1FrontText.text = player1BackText.text = "LOSE";
            }
        }
    }
}
