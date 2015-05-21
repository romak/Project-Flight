using UnityEngine;
using System.Collections;

public class RsDamageBase : MonoBehaviour
{
    public float m_health = 100f;

    void Awake()
    {
        m_health = 100f;
    }

    protected virtual float TakeDamage(float amount)
    {

        m_health -= amount;
        m_health = Mathf.Clamp(m_health, 0, 100);
        OnDamage(amount);

        if (m_health <= 0f)
        {
            OnDeath();
        }
        //print("TakeDamage(float amount) " + m_health);

        return m_health;

    }

    protected virtual void OnDeath()
    {
        //print("OnDeath()");
    }

    protected virtual void OnDamage(float damage)
    {
    }

}
