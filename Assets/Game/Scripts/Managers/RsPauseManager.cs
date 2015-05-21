using UnityEngine;
using System.Collections;

public class RsPauseManager : MonoBehaviour
{
    private bool paused;
    private float timeScaleRef = 1f;
    private float volumeRef = 1f;

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
        timeScaleRef = Time.timeScale;
        Time.timeScale = 0f;

        volumeRef = AudioListener.volume;
        AudioListener.volume = 0f;

        paused = true;
    }

    public void TogglePauseOff()
    {
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
