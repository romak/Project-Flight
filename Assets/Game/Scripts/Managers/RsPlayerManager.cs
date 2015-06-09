using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Utility;

public class RsPlayerManager : MonoBehaviour
{
    public RsPlayerHealth playerHealth;
    public RsFuelManager fuelManager;
    public RsScoreManager scoreManager;
    public RsPlayerMovement playerMovement;
    public GameObject player;

    ObjectResetter objectResetter;

    public static RsPlayerManager m_instance = null;


    void InitSingleton()
    {
        if (m_instance == null)
            m_instance = this;
        else if (m_instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void Awake()
    {
        InitSingleton();

        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");

        objectResetter = player.GetComponent<ObjectResetter>();

    }

    public bool IsDeath()
    {
        return playerHealth.IsDeath();
    }


    public void AddScore(float value)
    {
        scoreManager.AddScore(value);
    }

    public void Reset()
    {
        objectResetter.DelayedReset(0);
        fuelManager.Reset();
        scoreManager.Reset();
        playerHealth.Reset();
    }

}
