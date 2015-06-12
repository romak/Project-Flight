using UnityEngine;
using System.Collections;

public class RsPauseManager : MonoBehaviour
{

    public GameObject inGameMenu;

    private bool paused;
    private float timeScaleRef = 1f;
    private float volumeRef = 1f;


    public void Awake()
    {
        inGameMenu.SetActive(false);
    }

    public bool IsPaused()
    {
        return paused;
    }

    public void TogglePause()
    {
        paused = !paused;

        if (paused)
            TogglePauseOn();

        if (!paused)
            TogglePauseOff();

    }

    public void TogglePauseOn()
    {
        inGameMenu.SetActive(true);

        timeScaleRef = Time.timeScale;
        Time.timeScale = 0f;

        volumeRef = AudioListener.volume;
        AudioListener.volume = 0f;

        paused = true;
    }

    public void TogglePauseOff()
    {
        inGameMenu.SetActive(false);

        Time.timeScale = timeScaleRef;
        AudioListener.volume = volumeRef;
        paused = false;
    }


#if !MOBILE_INPUT
	void Update()
	{
		if(Input.GetKeyUp(KeyCode.Escape))
		{
            TogglePause();
		}
	}
#endif
}
