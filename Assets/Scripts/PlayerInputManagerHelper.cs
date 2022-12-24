using UnityEngine;
using UnityEngine.InputSystem;

public sealed class PlayerInputManagerHelper : MonoBehaviour
{
    private static PlayerInputManagerHelper instance;

    private PlayerInputManager playerInputManager;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

        if (!TryGetComponent<PlayerInputManager>(out playerInputManager))
        {
            Destroy(this);
            return;
        }
    }

    private void OnEnable()
    {
        playerInputManager.onPlayerJoined += OnPlayerJoined;
    }

    private void OnDisable()
    {
        playerInputManager.onPlayerJoined -= OnPlayerJoined;
    }

    private void OnPlayerJoined(PlayerInput playerInput)
    {
        playerInput.transform.SetParent(this.transform, true);
    }

    public bool TryGetPlayerInput(int playerIndex, out PlayerInput playerInput)
    {
        var playerInputs = GetComponentsInChildren<PlayerInput>();

        foreach (var input in playerInputs)
        {
            if (input.playerIndex == playerIndex)
            {
                playerInput = input;
                return true;
            }
        }

        playerInput = null;
        return false;
    }
}
