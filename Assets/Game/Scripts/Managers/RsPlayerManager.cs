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

    public bool IsDeath()
    {
        return playerHealth.IsDeath();
    }

    void Start()
    {
        objectResetter = player.GetComponent<ObjectResetter>();
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
