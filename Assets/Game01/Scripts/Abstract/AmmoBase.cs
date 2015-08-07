using UnityEngine;
using System.Collections;

public class AmmoBase : MonoBehaviour
{
    /// <summary> 
    /// bla bla bla
    /// </summary> 
    [SerializeField]
    protected float m_hitDamage = 10f;

    [SerializeField]
    protected AudioClip m_fireSound;
    protected AudioSource m_audioSource;
    protected GameObject m_collisionExplosion;
    protected float m_collisionExplosionTime = 2f;

    protected Renderer m_renderer;

    void Awake()
    {
        //m_audioSource = GetComponent<AudioSource>();
    }

    public virtual AmmoBase SpawnAmmo(Transform _trasform)
    {
        GameObject ammoObject = GameObject.Instantiate(gameObject, _trasform.position, _trasform.rotation) as GameObject;
        AmmoBase ammo = ammoObject.GetComponent<AmmoBase>();

        if (m_audioSource != null)
            m_audioSource.PlayOneShot(ammo.m_fireSound);

        return ammo;
    }

    protected virtual void DamageTarget(GameObject target)
    {
        target.SendMessage("TakeDamage", m_hitDamage, SendMessageOptions.DontRequireReceiver);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {

        if (RendererExtensions.IsVisibleFrom(m_renderer, Camera.main))
        {
            if (other.gameObject.CompareTag("Static"))
            {
                Destroy(gameObject);
            }

            if (other.gameObject.CompareTag("Fuel"))
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("LevelBounds"))
        {
            Destroy(gameObject);
        }
    }


}
