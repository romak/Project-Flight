using UnityEngine;
using System.Collections;

public class Bullet : AmmoBase
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

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }

    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
    }

    void OnCollisionEnter(Collision col)
    {
        if (RsRendererExtensions.IsVisibleFrom(m_renderer, Camera.main))
        {
            DamageTarget(col.gameObject);
            if (m_collisionExplosion != null)
            {
                GameObject explotion = (GameObject)Instantiate(m_collisionExplosion, gameObject.transform.position, Quaternion.identity);
                Destroy(explotion, m_collisionExplosionTime);
            }

            Destroy(gameObject);
        }
    }

}
