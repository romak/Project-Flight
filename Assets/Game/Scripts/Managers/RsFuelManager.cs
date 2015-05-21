using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RsFuelManager : MonoBehaviour
{
    public Slider slider;
    public float timeRate = 0.3f;
    public float countRate = 0.5f;

    bool fuelEmpty = false;
    float fuel = 100f; // max 100
    float nextTime = 0.0f;

    RsPlayerHealth playerHealth;
    RsPlayerSettings playerSettings;

    void Awake()
    {
        playerHealth = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<RsPlayerHealth>();
        playerSettings = GameObject.FindGameObjectWithTag("PlayerSettings").GetComponent<RsPlayerSettings>();
    }

    void UpdateFuel()
    {
        if (playerSettings.infiniteFuel)
            return;

        if (Time.time > nextTime && !fuelEmpty)
        {
            nextTime = Time.time + timeRate;
            fuel -= countRate;
            fuel = Mathf.Clamp(fuel, 0, 100);
            slider.value = fuel;
            if (fuel <= 0)
            {
                fuelEmpty = true;
                playerHealth.Death();
                // TODO: make something
            }
        }

    }

    void Update()
    {
        UpdateFuel();
    }

    public void Reset()
    {
        fuelEmpty = false;
        fuel = 100f;
    }

    public void AddFuel(float value)
    {
        fuel += value;
        fuel = Mathf.Clamp(fuel, 0, 100);
    }

}
