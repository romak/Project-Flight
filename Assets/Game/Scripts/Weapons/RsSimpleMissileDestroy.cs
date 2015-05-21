using UnityEngine;
using System.Collections;

public class RsSimpleMissileDestroy : MonoBehaviour
{
    public GameObject explosion;

    //private Collider col;

    void Awake()
    {
        //col = GameObject.Find("Missile").GetComponent<Collider>();
    }
    void OnCollisionEnter(Collision collision)
    {
        /*
        if (collision.gameObject.tag == "Player")
        {
            //Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
            Physics.IgnoreCollision(collision.collider, col);
        }
         */

        if (explosion != null && collision.gameObject.tag != "Player")
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }

        if (collision.gameObject.tag != "Player")
        {
            Destroy(gameObject, 0);
        }
    }
}
