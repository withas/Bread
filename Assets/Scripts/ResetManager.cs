using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public sealed class ResetManager : MonoBehaviour
{
    private void Update()
    {
        // Debug.Log(Keyboard.current);
        if(Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            StartCoroutine(SceneReset());
        }
    }

    private IEnumerator SceneReset()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("TitleScene");
    }
}
