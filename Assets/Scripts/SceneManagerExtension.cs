using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneManagerExtension
{
    public static bool TryGetComponentInScene<TComponent>(string sceneName, out TComponent component) where TComponent : Component
    {
        var scene = SceneManager.GetSceneByName(sceneName);

        var gameObjects = scene.GetRootGameObjects();

        foreach (var gameObject in gameObjects)
        {
            component = gameObject.GetComponentInChildren<TComponent>();
            if (component != null)
            {
                return true;
            }
        }

        component = null;
        return false;
    }
}
