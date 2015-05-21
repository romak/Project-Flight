using UnityEngine;
using System.Collections;

public class RsGunLauncher : RsWeaponLauncherBase
{
    public float m_ammoPerShoot = 1f;
    public float m_maxAmmo = 10f;
    public float m_timeRate = 1.0f;
    public Transform m_lauchPoint;
    public AudioClip m_shootClip;
    private AudioSource m_audioSource;
    protected float m_nextTime = 0.0f;
    private float m_currentAmmo;

    void Awake()
    {
        m_audioSource = GetComponent<AudioSource>();
        m_currentAmmo = m_maxAmmo;
        m_nextTime = Time.time;
    }

    public override void Fire()
    {
        if (Time.time > m_nextTime)
        {
            if ((m_currentAmmo > 0 || m_maxAmmo == 0f))
            {
                if (m_audioSource != null && m_shootClip != null)
                {
                    m_audioSource.PlayOneShot(m_shootClip);
                }

                m_ammo.SpawnAmmo(m_lauchPoint);

                if (m_maxAmmo != 0.0f)
                {
                    m_currentAmmo -= m_ammoPerShoot;
                    m_currentAmmo = Mathf.Clamp(m_currentAmmo, 0, m_maxAmmo);
                }
            }
            m_nextTime = Time.time + m_timeRate;
        }
    }

}
