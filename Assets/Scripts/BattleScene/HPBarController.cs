using UnityEngine;
using UnityEngine.UI;

public class HPBarController : MonoBehaviour {
    private Slider slider;
    private PlayerController playerController;

    // HPバーにプレイヤーを設定する
    public void SetPlayer(GameObject playerObject) {
        this.playerController = playerObject.GetComponent<PlayerController>();

        this.slider.maxValue = this.playerController.GetMaxHp();
        this.slider.value = this.playerController.GetHp();
    }

    private void Awake() {
        this.slider = this.GetComponent<Slider>();
    }

    private void Update() {
        if (this.playerController != null) {
            // 値を更新する
            this.slider.value = this.playerController.GetHp();
        }
    }
}
