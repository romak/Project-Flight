using UnityEngine;
using System.Collections;

public class RsHomingMissile : MonoBehaviour
{
    public float speed = 40.0f;
    public string targetTag;

    GameObject target;
    GameObject lastTarget;

    RsPlayerHealth playerHealth;
    Rigidbody m_rigidBody;

    void Awake()
    {
        m_rigidBody = GetComponent<Rigidbody>();
        playerHealth = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<RsPlayerHealth>();
    }

    GameObject FindClosestEnemy(string tag)
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag(tag);
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;

            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }


    void FixedUpdate()
    {
        m_rigidBody.AddForce(transform.TransformDirection(Vector3.forward) * speed);

        target = FindClosestEnemy(targetTag);

        if (target != null)
        {
            Vector3 relativePos = target.transform.position - transform.position;
            Vector3 forward = transform.forward;

            float angle = Vector3.Angle(relativePos, forward);
            float dist = Vector3.Distance(target.transform.position, transform.position);

            // kill self if target backward missile
            Vector3 dir = relativePos / relativePos.magnitude;
            if (dir.z > 0.0f)
            {
                Destroy(gameObject, 0.5f);
            }

            if ((angle >= 0f && angle <= 20f) && (dist > 5f))
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(relativePos), speed * Time.deltaTime);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Static")
        {
            Destroy(gameObject);
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == targetTag)
        {
            playerHealth.TakeDamage(50);
        }

        Destroy(gameObject);
    }

}
