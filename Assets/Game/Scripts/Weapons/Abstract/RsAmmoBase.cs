using UnityEngine;
using System.Collections;

public class RsAmmoBase : MonoBehaviour
{
    /// <summary> 
    /// bla bla bla
    /// </summary> 
    [SerializeField]
    protected float m_hitDamage = 10f;

    [SerializeField]
    protected AudioClip m_fireSound;
    private AudioSource m_audioSource;

    void Awake()
    {
        m_audioSource = GetComponent<AudioSource>();
    }

    public virtual RsAmmoBase SpawnAmmo(Transform _trasform)
    {
        GameObject ammoObject = GameObject.Instantiate(gameObject, _trasform.position, _trasform.rotation) as GameObject;
        RsAmmoBase ammo = ammoObject.GetComponent<RsAmmoBase>();

        if (m_audioSource != null)
            m_audioSource.PlayOneShot(ammo.m_fireSound);

        return ammo;
    }

    protected virtual void DamageTarget(GameObject target)
    {
        //print("DamageTarget " + target.gameObject.tag);
        target.SendMessage("TakeDamage", m_hitDamage, SendMessageOptions.DontRequireReceiver);
    }


}
