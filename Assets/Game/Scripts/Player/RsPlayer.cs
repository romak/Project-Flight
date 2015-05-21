using UnityEngine;
using System.Collections;

public class RsPlayer : MonoBehaviour
{
    private RsGunLauncher m_gunLauncher;
    public RsMissileLauncher m_missileLauncher1;
    public RsMissileLauncher m_missileLauncher2;
    //public Transform m_bulletPosition;

    void Awake()
    {
        m_gunLauncher = GetComponent<RsGunLauncher>();
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


}
