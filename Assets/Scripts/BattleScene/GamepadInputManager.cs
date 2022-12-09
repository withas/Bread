using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GamepadInputManager : MonoBehaviour {
    // public GameObject gamepadPlayer;

    private PlayerController playerController;

    // Start is called before the first frame update
    void Start() {
        // playerController = gamepadPlayer.GetComponent<PlayerController>();
    }

    public void SetPlayer(GameObject player) {
        this.playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update() {
        if (!this.playerController.enabled) return;

        // ジョイスティックが接続されているとき
            if (Joystick.current != null) {
            // 左右移動
            float x = Joystick.current.stick.x.ReadValue();
            if (x >= 0.5f) playerController.OnMove(1.0f);
            else if (x <= -0.5f) playerController.OnMove(-1.0f);
            else playerController.OnMove(0);

            // ジャンプ
            if (Joystick.current.stick.y.ReadValue() > 0) playerController.OnJump();

            // 攻撃
            if (Input.GetKeyDown("joystick button 0")) playerController.OnAttack1();
            else if (Input.GetKeyDown("joystick button 2")) playerController.OnAttack2();

            // ガード
            if (Input.GetKey("joystick button 5")) playerController.OnGuard();
            else if (Input.GetKeyUp("joystick button 5")) playerController.OffGuard();

            // ボタン確認用
            if (Input.GetKeyDown("joystick button 0")) Debug.Log("button0");
            if (Input.GetKeyDown("joystick button 1")) Debug.Log("button1");
            if (Input.GetKeyDown("joystick button 2")) Debug.Log("button2");
            if (Input.GetKeyDown("joystick button 3")) Debug.Log("button3");
            if (Input.GetKeyDown("joystick button 4")) Debug.Log("button4");
            if (Input.GetKeyDown("joystick button 5")) Debug.Log("button5");
            if (Input.GetKeyDown("joystick button 6")) Debug.Log("button6");
            if (Input.GetKeyDown("joystick button 7")) Debug.Log("button7");
            if (Input.GetKeyDown("joystick button 8")) Debug.Log("button8");
            if (Input.GetKeyDown("joystick button 9")) Debug.Log("button9");

            return;
        }

        // PS4かXInputのコントローラーが接続されているとき
        if (Gamepad.current != null) {
            // 左スティックの状況を読み取る
            Vector2 v = Gamepad.current.leftStick.ReadValue();

            // 十字キーが押されている場合上書き
            if (Gamepad.current.dpad.left.isPressed) v.x = -1.0f;
            else if (Gamepad.current.dpad.right.isPressed) v.x = 1.0f;
            if (Gamepad.current.dpad.up.isPressed) v.y = 1.0f;

            // 左右移動
            if (v.x >= 0.5f) playerController.OnMove(1.0f);
            else if (v.x <= -0.5f) playerController.OnMove(-1.0f);
            else playerController.OnMove(0);

            // ジャンプ
            if (v.y > 0.5f) playerController.OnJump();

            // 攻撃キー
            if (Gamepad.current.buttonWest.wasPressedThisFrame) playerController.OnAttack1();
            else if (Gamepad.current.buttonSouth.wasPressedThisFrame) playerController.OnAttack2();

            // ガード
            if (Gamepad.current.rightShoulder.isPressed) playerController.OnGuard();
            else if (Gamepad.current.rightShoulder.wasReleasedThisFrame) playerController.OffGuard();

            return;
        }
    }
}
