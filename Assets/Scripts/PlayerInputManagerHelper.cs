using UnityEngine;
using UnityEngine.InputSystem;

public sealed class PlayerInputManagerHelper : MonoBehaviour
{
    public static PlayerInputManagerHelper Instance { get; private set; }

    private PlayerInputManager playerInputManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
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
