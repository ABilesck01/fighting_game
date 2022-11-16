using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    private static string nextScene;

    public static void LoadScene(string name)
    {
        nextScene = name;
        SceneManager.LoadSceneAsync("Loading");
    }

    private void Start()
    {
        if (!string.IsNullOrEmpty(nextScene))
            StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        AsyncOperation operation = new AsyncOperation();

        operation = SceneManager.LoadSceneAsync(nextScene);
        SceneManager.UnloadSceneAsync("Loading");

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            yield return null;
        }
    }
}
