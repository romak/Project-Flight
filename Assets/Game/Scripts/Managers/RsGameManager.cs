using UnityEngine;
using System.Collections;

public class RsGameManager : MonoBehaviour
{
    public RsGameSettings gameSettings;
    public RsLevelManager levelManager;
    public RsPauseManager pauseManager;

    public GameObject mainCamera;
    public GameObject freeCamera;

    void Start()
    {
        mainCamera.SetActive(true);
        freeCamera.SetActive(false);
    }

    void ToggleCamera()
    {
        mainCamera.SetActive(!mainCamera.activeSelf);
        freeCamera.SetActive(!freeCamera.activeSelf);
        pauseManager.TogglePause();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ToggleCamera();
        }
    }


    void OnDestroy()
    {
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if ((pauseStatus) && (!pauseManager.IsPaused()))
        {
            pauseManager.TogglePauseOn();
        }

     //   if ((!pauseStatus) && (pauseManager.IsPaused()))
       //     pauseManager.TogglePauseOff();
    }


    public void QuitGame()
    {
        // TODO: ask for action and animation, etc.

        Application.Quit();
    }


}
