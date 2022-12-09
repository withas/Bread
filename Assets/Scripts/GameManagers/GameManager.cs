using UnityEngine;

namespace SelectCharacter
{
    public sealed class GameManager : MonoBehaviour
    {
        private static GameManager gameManager;

        //　ゲーム全体で管理するデータ
        [SerializeField]
        private GameManagerDate gameManagerData = null;

        private void Awake()
        {
            //　世界に一つだけのMyGameManagerにする処理
            if (gameManager == null)
            {
                gameManager = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        //　MyGameManagerDataを返す
        public GameManagerDate GetGameManagerData()
        {
            return gameManagerData;
        }
    }
}
