﻿using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class RsPlayerSettings : MonoBehaviour
{
    [System.Serializable]
    public class RsPlayerSettingData
    {
        public bool developer = true;
        public bool showFPS = true;
        public bool showPauseButton = true;
        public bool showRestartButton = true;
        public bool showFireButton = true;
        public bool showResetButton = true;
        public bool infiniteFuel = true;
        public bool infiniteLife = true;

        public RsPlayerSettingData()
        {
        }
    }

    public bool developer;
    public bool showFPS;
    public bool showPauseButton;
    public bool showRestartButton;
    public bool showFireButton;

    public bool infiniteFuel = true;
    public bool infiniteLife = true;

    private string fileName = "playerSettings.dat";
    private string filePath;
    private RsPlayerSettingData playerSettingsData = new RsPlayerSettingData();

    void FindAndSetActive(string name, bool active)
    {
        GameObject ob = GameObject.FindGameObjectWithTag(name);
        if (ob != null)
            ob.SetActive(active);
    }

    void Awake()
    {
        filePath = Application.persistentDataPath + "/" + fileName;

        //Load();

        FindAndSetActive("FPSCounter", showFPS);
        FindAndSetActive("PauseButton", showPauseButton);
        FindAndSetActive("RestartButton", showRestartButton);
        FindAndSetActive("FireButton", showFireButton);
    }

    void OnDestroy()
    {
        Save();
    }

    public void Save()
    {
        playerSettingsData.developer = developer;
        playerSettingsData.showFPS = showFPS;
        playerSettingsData.showPauseButton = showPauseButton;
        playerSettingsData.showRestartButton = showRestartButton;
        playerSettingsData.showFireButton = showFireButton;
        playerSettingsData.infiniteFuel = infiniteFuel;
        playerSettingsData.infiniteLife = infiniteLife;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(filePath);
        bf.Serialize(file, playerSettingsData);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/" + fileName))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(filePath, FileMode.Open);
            playerSettingsData = (RsPlayerSettingData)bf.Deserialize(file);
            file.Close();

            SetValues();
        }
    }

    void SetValues()
    {
        if (playerSettingsData != null)
        {
            developer = playerSettingsData.developer;
            showFPS = playerSettingsData.showFPS;
            showPauseButton = playerSettingsData.showPauseButton;
            showRestartButton = playerSettingsData.showRestartButton;
            showFireButton = playerSettingsData.showFireButton;
            infiniteFuel = playerSettingsData.infiniteFuel;
            infiniteLife = playerSettingsData.infiniteLife;
        }

    }


}
