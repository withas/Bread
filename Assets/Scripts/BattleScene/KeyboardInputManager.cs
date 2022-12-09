using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyboardInputManager : MonoBehaviour
{
    private PlayerController playerController;

    public void SetPlayer(GameObject player)
    {
        this.playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current == null || !this.playerController.enabled) return;

        // 移動キー
        if (Keyboard.current.rightArrowKey.isPressed) playerController.OnMove(1.0f);
        else if (Keyboard.current.leftArrowKey.isPressed) playerController.OnMove(-1.0f);
        else playerController.OnMove(0);

        // 上キーが押された瞬間ジャンプ
        if (Keyboard.current.upArrowKey.wasPressedThisFrame) playerController.OnJump();

        // 攻撃キー
        if (Keyboard.current.zKey.wasPressedThisFrame) playerController.OnAttack1();
        else if (Keyboard.current.xKey.wasPressedThisFrame) playerController.OnAttack2();

        // ガードキー
        if (Keyboard.current.shiftKey.isPressed) playerController.OnGuard();
        else if (Keyboard.current.shiftKey.wasReleasedThisFrame) playerController.OffGuard();
    }
}
