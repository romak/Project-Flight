using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class RsGameSettings : MonoBehaviour
{

    [System.Serializable]
    public class RsGameSettingData
    {
        public bool soundMute;
        public bool musicMute;
        public float soundVolume;
        public float musicVolume;

        public RsGameSettingData()
        {
            soundMute = false;
            musicMute = false;
            soundVolume = 1f;
            musicVolume = 1f;
        }
    }

    public bool soundMute;
    public bool musicMute;
    public float soundVolume = 1f;
    public float musicVolume = 1f;
    public AudioSource gameBackgroundMusic;

    private string fileName = "rs_settings.dat";
    private string filePath;
    private RsGameSettingData gameSettingsData = new RsGameSettingData();

    void Awake()
    {
        filePath = Application.persistentDataPath + "/" + fileName;

        //Load();
    }

    void OnDestroy()
    {
        Save();
    }

    public void Save()
    {
        gameSettingsData.musicMute = musicMute;
        gameSettingsData.soundMute = soundMute;
        gameSettingsData.soundVolume = soundVolume;
        gameSettingsData.musicVolume = musicVolume;

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
        }
    }

    void SetValues()
    {
        if (gameSettingsData != null)
        {
            musicMute = gameSettingsData.musicMute;
            soundMute = gameSettingsData.soundMute;
            musicVolume = gameSettingsData.musicVolume;
            soundVolume = gameSettingsData.soundVolume;

            gameBackgroundMusic.mute = musicMute;
            gameBackgroundMusic.volume = musicVolume;

            AudioListener.volume = soundVolume;
            AudioListener.pause = soundMute;
        }

    }


}


