using UnityEngine;
using System.Collections;

public class RsBullet : RsAmmoBase
{
    [SerializeField]
    private float m_forwardSpeed = 20f;

    void Awake()
    {
        base.m_renderer = GetComponent<Renderer>();
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * (Time.deltaTime * m_forwardSpeed));
    }

    void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }

    void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
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
