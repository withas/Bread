using UnityEngine;
using UnityEngine.InputSystem.UI;

public sealed class SelectCharaCanvas : MonoBehaviour
{
    [SerializeField]
    private SelectCharaPanelDirector selectCharaPanelDirector;

    public SelectCharaPanelDirector SelectCharaPanelDirector => selectCharaPanelDirector;

    [SerializeField]
    private InputSystemUIInputModule uiInputModule;

    public InputSystemUIInputModule UIInputModule => uiInputModule;
}
