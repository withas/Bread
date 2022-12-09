using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UniRx;
using UniRx.Triggers;
using Cysharp.Threading.Tasks;

public sealed class TitleSceneManager : MonoBehaviour
{
    [SerializeField]
    private Fade fade;

    [SerializeField]
    private string nextSceneName;

    private InputAction inputAction;

    private void Awake()
    {
        inputAction = new InputAction(type: InputActionType.PassThrough, binding: "*/<Button>", interactions: "Press", expectedControlType: "Button");
    }

    private void OnEnable()
    {
        inputAction?.Enable();
    }

    private void OnDisable()
    {
        inputAction?.Disable();
    }

    private void Start()
    {
        this.UpdateAsObservable()
            .FirstOrDefault(_ => inputAction.triggered)
            .Subscribe(_ => OnNextScene().Forget());
    }

    // ゲームスタート
    private async UniTaskVoid OnNextScene()
    {
        // トランジションを掛けてシーン遷移する
        await fade.FadeIn(1.0f);

        SceneManager.LoadScene(nextSceneName);
    }
}
