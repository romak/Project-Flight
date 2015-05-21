using UnityEngine;
using System.Collections;

public class RsBullet : RsAmmoBase
{
    [SerializeField]
    private float m_forwardSpeed = 20f;

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
        //Destroy(col.gameObject);
        Destroy(gameObject);
    }

}
