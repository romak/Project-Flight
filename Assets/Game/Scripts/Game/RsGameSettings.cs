using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.Audio;

public class RsGameSettings : MonoBehaviour
{

    [System.Serializable]
    public class RsGameSettingData
    {
        public bool soundMute;
        public bool musicMute;
        public float soundVolume;
        public float musicVolume;

        public int renderQuality;

        public RsGameSettingData()
        {
            soundMute = false;
            musicMute = false;
            soundVolume = 0f;
            musicVolume = 0f;
        }
    }

    public bool soundMute;
    public bool musicMute;
    public float soundVolume = 0f;
    public float musicVolume = 0f;
    public int renderQuality = 0;

    public AudioMixer mainMixer;					//Used to hold a reference to the AudioMixer mainMixer

    private string fileName = "settings.dat";
    private string filePath;
    private RsGameSettingData gameSettingsData = new RsGameSettingData();

    void Awake()
    {
        filePath = Application.persistentDataPath + "/" + fileName;

        Load();
    }

    void Start()
    {
    }

    void OnDestroy()
    {
        Save();
    }

    public void Save()
    {

        mainMixer.GetFloat("sfxVol", out soundVolume);
        mainMixer.GetFloat("musicVol",out musicVolume);

        print("Save "+musicVolume);

        gameSettingsData.musicMute = musicMute;
        gameSettingsData.soundMute = soundMute;
        gameSettingsData.soundVolume = soundVolume;
        gameSettingsData.musicVolume = musicVolume;
        gameSettingsData.renderQuality = renderQuality;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(filePath);
        bf.Serialize(file, gameSettingsData);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/" + fileName))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(filePath, FileMode.Open);
            gameSettingsData = (RsGameSettingData)bf.Deserialize(file);
            file.Close();

            SetValues();

            ApllySettings();
        }
    }

    public void ApllySettings()
    {
        mainMixer.SetFloat("sfxVol", gameSettingsData.soundVolume);
        mainMixer.SetFloat("musicVol", gameSettingsData.musicVolume);
    }

    void SetValues()
    {
        if (gameSettingsData != null)
        {
            musicMute = gameSettingsData.musicMute;
            soundMute = gameSettingsData.soundMute;
            musicVolume = gameSettingsData.musicVolume;
            soundVolume = gameSettingsData.soundVolume;
            renderQuality = gameSettingsData.renderQuality;
        }

    }

    public void SetMusicLevel(float musicLvl)
    {
        mainMixer.SetFloat("musicVol", musicLvl);
    }

    //Call this function and pass in the float parameter sfxLevel to set the volume of the AudioMixerGroup SoundFx in mainMixer
    public void SetSfxLevel(float sfxLevel)
    {
        mainMixer.SetFloat("sfxVol", sfxLevel);
    }

}


