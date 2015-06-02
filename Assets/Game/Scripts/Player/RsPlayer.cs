using UnityEngine;
using System.Collections;

public class RsPlayer : MonoBehaviour
{
    private RsGunLauncher m_gunLauncher;
    public RsMissileLauncher m_missileLauncher1;
    public RsMissileLauncher m_missileLauncher2;
    RsPlayerHealth playerHealth;

    void Awake()
    {
        m_gunLauncher = GetComponent<RsGunLauncher>();
        playerHealth = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<RsPlayerHealth>();

    }

    void Update()
    {

        if (!playerHealth.IsDeath())
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
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("LevelBounds"))
        {
            playerHealth.Death();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Static"))
        {
            playerHealth.Death();
        }

    }


}
