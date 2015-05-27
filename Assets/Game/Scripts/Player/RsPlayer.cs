using UnityEngine;
using System.Collections;

public class RsPlayer : MonoBehaviour
{
    private RsGunLauncher m_gunLauncher;
    public RsMissileLauncher m_missileLauncher1;
    public RsMissileLauncher m_missileLauncher2;
    RsPlayerHealth playerHealth;

    //public Transform m_bulletPosition;

    void Awake()
    {
        m_gunLauncher = GetComponent<RsGunLauncher>();
        playerHealth = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<RsPlayerHealth>();

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            m_gunLauncher.Fire();
        }

        if (Input.GetKeyDown("space"))
        {
            m_missileLauncher1.Fire();
            m_missileLauncher2.Fire();
        }

    }


    void OnCollisionEnter(Collision collision)
    {
        //print(collision.gameObject.tag);
        if (collision.gameObject.tag == "Static")
        {
            playerHealth.Death();
        }

    }


}
