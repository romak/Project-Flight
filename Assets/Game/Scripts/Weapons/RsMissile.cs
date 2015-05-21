using UnityEngine;
using System.Collections;

public class RsMissile : RsAmmoBase
{
    public float m_forwardSpeed = 10f;

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * (Time.deltaTime * m_forwardSpeed));
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "LevelBounds")
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        DamageTarget(col.gameObject);
        Destroy(gameObject);
    }

}
