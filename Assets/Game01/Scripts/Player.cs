using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public Camera camera;

    public GameObject bullet;
    public float bulletSpeed = 2.0f;

    public GameObject rocket;
    public float rocketSpeed = 0.5f;

    public GameObject forceField;
    public bool forceFieldEnabled = false;

    public bool isTouchingGround = false;

    public AudioSource crashSound;

    void Awake()
    {

    }

    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {

    }

    void OnCollisionEnter(Collision collision)
    {

    }

    void OnCollisionStay(Collision collisionInfo)
    {

    }

}
