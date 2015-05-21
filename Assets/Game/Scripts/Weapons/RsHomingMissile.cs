using UnityEngine;
using System.Collections;

public class RsHomingMissile : MonoBehaviour
{
    public float speed = 40.0f;
    //public ParticleSystem ps;
    //public Transform psPosition;

    public string targetTag;

    GameObject target;
    GameObject lastTarget;
    //Rigidbody rb;

    RsPlayerHealth playerHealth;

    void Awake()
    {
      //  rb = GetComponent<Rigidbody>();
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
        GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.forward) * speed);
        target = FindClosestEnemy(targetTag);

        if (target != null)
        {
            //print(target.name);
            Vector3 relativePos = target.transform.position - transform.position;
            Vector3 forward = transform.forward;

            float angle = Vector3.Angle(relativePos, forward);
            float dist = Vector3.Distance(target.transform.position, transform.position);

            if ((angle >= 0f && angle <= 30f) && (dist > 3f))
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(relativePos), speed * Time.deltaTime);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(50);
        }

        Destroy(gameObject);
    }

}
