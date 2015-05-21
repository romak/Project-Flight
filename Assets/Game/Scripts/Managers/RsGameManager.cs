using UnityEngine;
using System.Collections;

public class RsGameManager : MonoBehaviour
{
    public RsGameSettings gameSettings;
    public RsLevelManager levelManager;
    public RsPauseManager pauseManager;

    void Awake()
    {

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
