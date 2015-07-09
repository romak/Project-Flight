using UnityEngine;
using System.Collections;

public class ForceField : MonoBehaviour
{

    public float rotationVelocity = 20.0f;

    private Transform m_transform;

    void Awake()
    {
        m_transform = gameObject.transform;
    }

    void Update()
    {
        m_transform.Rotate(Vector3.up * Time.deltaTime * rotationVelocity, Space.World);

    }

}
