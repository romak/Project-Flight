using UnityEngine;
using System.Collections;

public class RsFuelPower : MonoBehaviour
{

    public AudioClip wayAudio; // ссылка на аудио заправки топлива
    public float blinkSpeed = 3.0f;  // скорость мерцания
    public float sizeFuel = 35;  // емкость заправки 
    public float fuelTime = 2.0f;  // время перебывания для получения fuelUnitsTime  x - единиц
    public float fuelUnitsTime = 5.0f; // количество единиц енергии ( за время перебывания )
    private float nextFuel = 0.0f;

    AudioSource audioSource;
    MeshRenderer mesh;
    RsFuelManager fuelManager;

    public void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
        audioSource = GetComponent<AudioSource>();
        fuelManager = GameObject.FindGameObjectWithTag("FuelManager").GetComponent<RsFuelManager>();
    }


    bool isPlayer(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            return true;
        return false;
    }


    void Blink()
    {
        //float t = Mathf.PingPong(Time.time * blinkSpeed, 1.0f);
        //mesh.material.color = Color.Lerp(Color.blue, Color.white, t);
    }

    void AddFuel()
    {

        if (Time.time > nextFuel && sizeFuel > 0)
        {


            float fueladd = Mathf.Min(sizeFuel, fuelUnitsTime);
            sizeFuel -= fueladd;
            fuelManager.AddFuel(fueladd);


            nextFuel = Time.time + fuelTime;
            if (wayAudio != null && audioSource != null && !audioSource.isPlaying)
            {
                audioSource.PlayOneShot(wayAudio);

            }

        }
        else if (sizeFuel == 0)
        {
            sizeFuel = -1;
            Destroy(gameObject, 2);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (isPlayer(other))
        {
            {
                Blink();
                AddFuel();
            }

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (audioSource != null || audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

}

