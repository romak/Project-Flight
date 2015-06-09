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
    public Text qualityText;
    public RsGameSettings gameSettings;
    public RsPlayerSettings playerSettings;
    public Slider musicVolumeSlider;
    public Toggle audioOff;
    public Toggle musOff;
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
        mainMenu.SetActive(true);
        settingMenu.SetActive(false);
        loadingImage.SetActive(false);

    }

    void Start()
    {
        audioOff.isOn = gameSettings.soundMute;
        musOff.isOn = gameSettings.musicMute;
        musicVolumeSlider.value = gameSettings.musicVolume;
        infiniteLife.isOn = playerSettings.infiniteLife;
        infiniteFuel.isOn = playerSettings.infiniteFuel;
        showFPS.isOn = playerSettings.showFPS;
        SetSliderFromQuality(gameSettings.renderQuality);
    }

    public void OnAudioOffChange()
    {
        gameSettings.soundMute = audioOff.isOn;
        gameSettings.ApllySettings();
    }

    public void OnMusicVolumeChange()
    {
        gameSettings.musicVolume = musicVolumeSlider.value;
        gameSettings.ApllySettings();
    }

    public void OnShowFPSChange()
    {
        playerSettings.showFPS = showFPS.isOn;
    }

    public void OnInfiniteLifeChange()
    {
        playerSettings.infiniteLife = infiniteLife.isOn;
    }

    public void OnInfiniteFuelChange()
    {
        playerSettings.infiniteFuel = infiniteFuel.isOn;
    }

    public void OnMusicOffChange()
    {
        gameSettings.musicMute = musOff.isOn;
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
