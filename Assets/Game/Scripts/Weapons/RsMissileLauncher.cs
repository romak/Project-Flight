using UnityEngine;
using System.Collections;

public class RsMissileLauncher : RsWeaponLauncherBase
{
    public float m_missilePerShoot = 1f;
    public float m_maxMissile = 10f;
    public float m_timeRate = 1.0f;
    public Transform m_lauchPoint;
    public AudioClip m_shootClip;
    private AudioSource m_audioSource;
    protected float m_nextTime = 0.0f;
    private float m_currentMissile;

    void Awake()
    {
        m_audioSource = GetComponent<AudioSource>();
        m_currentMissile = m_maxMissile;
        m_nextTime = Time.time;
    }

    public override void Fire()
    {
        if (Time.time > m_nextTime)
        {
            if ((m_currentMissile > 0 || m_maxMissile == 0f))
            {
                if (m_audioSource != null && m_shootClip != null)
                {
                    m_audioSource.PlayOneShot(m_shootClip);
                }

                m_ammo.SpawnAmmo(m_lauchPoint);

                if (m_maxMissile != 0.0f)
                {
                    m_currentMissile -= m_missilePerShoot;
                    m_currentMissile = Mathf.Clamp(m_currentMissile, 0, m_maxMissile);
                }
            }
            m_nextTime = Time.time + m_timeRate;
        }
    }


}
