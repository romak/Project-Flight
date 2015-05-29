using UnityEngine;
using System.Collections;

public class RsMissile : RsAmmoBase
{
    public float m_forwardSpeed = 10f;

    void Awake()
    {
        base.m_renderer = GetComponent<Renderer>();
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * (Time.deltaTime * m_forwardSpeed));
    }

    void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
    }

    
    void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }

    void OnCollisionEnter(Collision col)
    {
        if (RsRendererExtensions.IsVisibleFrom(m_renderer, Camera.main))
        {
            DamageTarget(col.gameObject);
            Destroy(gameObject);
        }
    }

}
