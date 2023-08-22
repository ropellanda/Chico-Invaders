using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public void SceneLoader(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Hardcore()
    {
        PlayerPrefs.SetInt("Hardcore", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene("GameView");
    }

    public void Normal()
    {
        PlayerPrefs.SetInt("Hardcore", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene("GameView");
    }
}
