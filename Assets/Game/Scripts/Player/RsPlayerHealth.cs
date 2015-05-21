using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RsPlayerHealth : MonoBehaviour
{

    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Text deathText;

    public float flashSpeed = 5.0f;
    public Color flashColor = new Color(0.1f, 0f, 0f, 0.5f);
    public Image damageImage;   // image for flash effect

    public bool damaged;

    public AudioClip deathClip;

    AudioSource playerAudio;

    bool isDead;
    RsPlayerSettings playerSettings;

    void Awake()
    {
        playerSettings = GameObject.FindGameObjectWithTag("PlayerSettings").GetComponent<RsPlayerSettings>();
        //  player = GameObject.FindGameObjectWithTag("Player");
        isDead = false;

        if (deathText!=null)
            deathText.enabled = false;
        currentHealth = startingHealth;
        playerAudio = GetComponent<AudioSource>();

    }

    public void Reset()
    {
        isDead = false;
        if (deathText != null)
            deathText.enabled = false;
        currentHealth = startingHealth;
    }

    void Update()
    {

        if (damageImage != null)
        {
            if (damaged)
            {
                damageImage.color = flashColor;
            }
            else
            {
                damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
            }
        }

        damaged = false;

    }

    public int TakeDamage(int amount)
    {
        damaged = true;

        if (playerSettings.infiniteLife)
            return currentHealth;

        damaged = true;
        currentHealth -= amount;

        if (healthSlider!=null)
            healthSlider.value = currentHealth;

        if (playerAudio != null)
            playerAudio.Play();

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }

        currentHealth = Mathf.Clamp(currentHealth, 0, 100);

        return currentHealth;
    }

    public bool IsDeath()
    {
        return isDead;
    }

    public void Death()
    {
        isDead = true;
        if (deathText != null)
            deathText.enabled = true;
        //playerAudio.clip = deathClip;
        //playerAudio.Play();
    }

}
