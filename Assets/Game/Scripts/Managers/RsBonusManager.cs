using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RsBonusManager : MonoBehaviour
{

    public class CrystalInfo
    {
        public int a;

        public CrystalInfo()
        {
        }

    };

    public CrystalInfo crystalInfo = new CrystalInfo();
    public Text crystalText;
    public ParticleSystem takeParticle;
    public AudioClip crystalSound;

    public Image fadeImage;
    public float fadeSpeed = 5.0f;
    public Color fadeColor = new Color(0.1f, 0f, 0f, 0.5f);
    public bool fadeOn = false;

    Transform psPosition;
    AudioSource audioSource;

    float crystals = 0f;

    void Awake()
    {
        fadeOn = false;
        audioSource = GetComponent<AudioSource>();
        crystals = 0f;
        if (crystalText != null)
            crystalText.text = crystals.ToString();
    }

    public void Reset()
    {
        crystals = 0f;
        if (crystalText != null)
            crystalText.text = crystals.ToString();
    }

    public float GetCrystals()
    {
        return crystals;
    }

    void Update()
    {
        if (fadeImage != null)
        {

            if (fadeOn)
            {
                fadeImage.color = fadeColor;
            }
            else
            {
                fadeImage.color = Color.Lerp(fadeImage.color, Color.clear, fadeSpeed * Time.deltaTime);
            }
        }

        fadeOn = false;
    }

    public void AddCrystals(float value, Transform _transfrom)
    {
        fadeOn = true;

        if (crystalSound != null)
        {
            audioSource.clip = crystalSound;
            audioSource.Play();
        }

        if (takeParticle != null)
        {
            ParticleSystem ps = Instantiate(takeParticle, _transfrom.position, _transfrom.rotation) as ParticleSystem;
            ps.Play();
        }

        crystals += value;
        if (crystalText != null)
            crystalText.text = crystals.ToString();
    }

}
