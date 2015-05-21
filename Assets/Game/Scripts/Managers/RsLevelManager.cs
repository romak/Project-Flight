using UnityEngine;
using System.Collections;

public class RsLevelManager : MonoBehaviour
{
    public int currentLevel;
    public RsLevel[] gameLevels;

    void Awake()
    {
        //string curScene = gameLevels[currentLevel].sceneName;
    }

    void OnDestroy()
    {
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        Application.LoadLevelAsync(Application.loadedLevel);
    }

    public void RestartLevelByName(string levelName)
    {
        Time.timeScale = 1f;
        Application.LoadLevelAsync(levelName);
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }

}
