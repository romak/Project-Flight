using UnityEngine;
using System.Collections;

public class DamageBase : MonoBehaviour
{
    public float m_maxHealth = 100f;
    public float m_health;

    void Awake()
    {
        m_health = m_maxHealth;
    }

    protected virtual float TakeDamage(float amount)
    {
        m_health -= amount;
        m_health = Mathf.Clamp(m_health, 0, m_maxHealth);
        OnDamage(amount);

        if (m_health <= 0f)
        {
            OnDeath();
        }

        return m_health;

    }

    protected virtual void OnDeath()
    {
    }

    protected virtual void OnDamage(float damage)
    {
    }

}
