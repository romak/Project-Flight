using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RsMenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settingMenu;
    public GameObject loadingImage;
    public Slider loadingSlider;
    public Slider qualitySlider;
    public Slider musicSlider;
    public Text qualityText;
    public RsGameSettings gameSettings;
    public RsPlayerSettings playerSettings;
    public Toggle audioOff;
    public Toggle musicOff;
    public Toggle infiniteLife;
    public Toggle infiniteFuel;
    public Toggle showFPS;

    private AsyncOperation async;
    private string levelName;


    void Awake()
    {
        //CanvasScaler canvasScaler = GetComponent<CanvasScaler>();
        //canvasScaler.referenceResolution = new Vector2(Screen.width, Screen.height);

        levelName = "level_00";

        RsUtils.SetActive(mainMenu, true);
        RsUtils.SetActive(settingMenu, false);
        RsUtils.SetActive(loadingImage, false);

    }

    void Start()
    {
        if (gameSettings != null)
        {
            audioOff.isOn = gameSettings.soundMute;
            
            if (musicOff != null)
                musicOff.isOn = gameSettings.musicMute;
            if (musicSlider != null)
                musicSlider.value = gameSettings.musicVolume;

            if (infiniteLife!=null)
                infiniteLife.isOn = playerSettings.infiniteLife;
            if (infiniteFuel!=null)
                infiniteFuel.isOn = playerSettings.infiniteFuel;
            if (showFPS!=null)
                showFPS.isOn = playerSettings.showFPS;
            SetSliderFromQuality(gameSettings.renderQuality);
        }
    }

    public void OnAudioOffChange()
    {
        if (gameSettings != null)
        {
            gameSettings.soundMute = audioOff.isOn;
            gameSettings.ApllySettings();
        }
    }

    public void OnMusicVolumeChange()
    {
        if (gameSettings != null)
        {
            gameSettings.musicVolume = musicSlider.value;
            gameSettings.ApllySettings();
        }
    }

    public void OnShowFPSChange()
    {
        if (gameSettings != null)
            playerSettings.showFPS = showFPS.isOn;
    }

    public void OnInfiniteLifeChange()
    {
        if (gameSettings != null)
            playerSettings.infiniteLife = infiniteLife.isOn;
    }

    public void OnInfiniteFuelChange()
    {
        if (gameSettings != null)
            playerSettings.infiniteFuel = infiniteFuel.isOn;
    }

    public void OnMusicOffChange()
    {
        gameSettings.musicMute = musicOff.isOn;
        
        gameSettings.ApllySettings();
    }

    void SetSliderFromQuality(int value)
    {
        if (value == 5)
            qualitySlider.value = 2;

        if (value == 3)
            qualitySlider.value = 1;

        if (value == 0)
            qualitySlider.value = 0;
    }

    void SetRenderQuality(int value)
    {
        if (gameSettings != null)
        {

            if (value == 0)
            {
                qualityText.text = "Low";
                gameSettings.renderQuality = 0;
                QualitySettings.SetQualityLevel(1);
            }

            if (value == 1)
            {
                qualityText.text = "Normal";
                gameSettings.renderQuality = 3;
                QualitySettings.SetQualityLevel(3);
            }

            if (qualitySlider.value == 2)
            {
                qualityText.text = "High";
                gameSettings.renderQuality = 5;
                QualitySettings.SetQualityLevel(5);
            }
        }
    }

    public void OnQualityChange()
    {
        SetRenderQuality((int)qualitySlider.value);
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    IEnumerator LoadLevel()
    {
        async = Application.LoadLevelAsync(levelName);
        while (!async.isDone)
        {
            loadingSlider.value = async.progress;
            yield return null;
        }
    }

    public void NewGame()
    {
        loadingImage.SetActive(true);
        StartCoroutine(LoadLevel());
    }

    public void QuitGame()
    {
        // TODO: ask for action and animation, etc.
        Application.Quit();
    }

}
