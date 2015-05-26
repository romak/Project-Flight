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
        mainCamera.SetActive(!mainCamera.active);
        freeCamera.SetActive(!freeCamera.active);
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
        if (pauseStatus)
            pauseManager.TogglePauseOn();

        if (!pauseStatus)
            pauseManager.TogglePauseOff();
    }

}
