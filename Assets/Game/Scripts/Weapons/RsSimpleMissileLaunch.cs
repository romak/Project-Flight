using UnityEngine;
using System.Collections;

public class RsSimpleMissileLaunch : MonoBehaviour
{
    //public Transform lauchPoint;
    //public Rigidbody missileRigidBody;
    //public float speed = 10.0f;
    //public AudioClip fireClip;

    //AudioSource audioSource;

    //private float missileTimeRate = 1.0f;
    //private float nextTime = 0.0F;

//    RsPlayerManager playerManager;

    void Awake()
    {
        //playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<RsPlayerManager>();
        //audioSource = GetComponent<AudioSource>();
        //if (audioSource != null)
        //    audioSource.clip = fireClip;

    }

    public void Fire()
    {
/*
        return;
        if ((lauchPoint == null) || (missileRigidBody == null))
            return;

        if (playerManager.IsDeath())
            return;

        if (Time.time > nextTime)
        {

            nextTime = Time.time + missileTimeRate;
            Rigidbody instance = Instantiate(missileRigidBody, lauchPoint.position, lauchPoint.rotation) as Rigidbody;
            instance.useGravity = false;
            instance.velocity = lauchPoint.forward * speed;

            if (audioSource != null && audioSource.clip != null)
                audioSource.Play();
        }
  */
    }

    //void Update()
    //{
    //    //        if (Input.GetButtonDown("Fire1"))
    //    if (Input.GetKeyDown("space"))
    //    {
    //        Fire();
    //    }
    //}

}
