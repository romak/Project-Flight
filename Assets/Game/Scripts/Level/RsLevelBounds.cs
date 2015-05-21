using UnityEngine;
using System.Collections;

public class RsLevelBounds : MonoBehaviour {

    RsPlayerHealth playerHealth;

    void Awake()
    {
        playerHealth = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<RsPlayerHealth>();
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerHealth.Death();
        }

    }

}
