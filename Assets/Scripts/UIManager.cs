using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void LoadGameScene()
    {
        // 防止加载时输入触发异常
        EventSystem.current.enabled = false;

        // 延迟一点点加载（可避免部分触发）
        StartCoroutine(LoadSceneDelay());
    }

    private IEnumerator LoadSceneDelay()
    {
        yield return null; // 等待一帧
        SceneManager.LoadScene("MainScene");
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}