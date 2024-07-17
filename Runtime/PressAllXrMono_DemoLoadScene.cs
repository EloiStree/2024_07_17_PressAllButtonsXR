using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAllXrMono_DemoLoadScene : MonoBehaviour
{

    public string m_loadSceneName = "Demo Scene";

    [ContextMenu("Load Index Scene")]
    public void LoadInInspectorScene() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(m_loadSceneName);
    }
    [ContextMenu("Load next scene")]
    public void LoadNextScene()
    {
        int indexCurrent = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        if (indexCurrent + 1 < UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings)
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
        else UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    [ContextMenu("Load zero")]

    public void LoadZeroScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void LoadScene(int index)
    {
        int indexCurrent = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        if (index < UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings)
            UnityEngine.SceneManagement.SceneManager.LoadScene(index);
        else UnityEngine.SceneManagement.SceneManager.LoadScene(0);

    }

}
