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

        public void ShowResult(Characters player1Chara, Characters player2Chara, int winnerNumber)
        {
            if (winnerNumber == 0)
            {
                if (winnerSpriteData.TryGetSprite(player1Chara, out var winnerSprite))
                {
                    player1Image.sprite = winnerSprite;
                }
                player1FrontText.text = player1BackText.text = "WIN";

                if (loserSpriteData.TryGetSprite(player2Chara, out var loserSprite))
                {
                    player2Image.sprite = loserSprite;
                }
                player2FrontText.text = player2BackText.text = "LOSE";
            }
            else if (winnerNumber == 1)
            {
                if (winnerSpriteData.TryGetSprite(player2Chara, out var winnerSprite))
                {
                    player2Image.sprite = winnerSprite;
                }
                player2FrontText.text = player2BackText.text = "WIN";

                if (loserSpriteData.TryGetSprite(player1Chara, out var loserSprite))
                {
                    player1Image.sprite = loserSprite;
                }
                player1FrontText.text = player1BackText.text = "LOSE";
            }
        }
    }
}
