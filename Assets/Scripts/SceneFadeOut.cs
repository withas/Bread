using UnityEngine;

public class SceneFadeOut : MonoBehaviour
{
    [SerializeField]
    private Fade fade;

    private void Start()
    {
        // fade.FadeOut(1f);
        fade.FadeOut(1f);
    }
}
