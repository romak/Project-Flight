﻿using UnityEngine;
using System.Collections;

public class RsSimpleEnemyMovement : RsDamageBase //RsEnemyDamage
{

    public GameObject missile;
    public Transform missilePos;

    public Transform target;
    public GameObject seeYouText;
    public Transform[] patrolWayPoints;

    NavMeshAgent agent;
    float patrolSpeed = 0.5f;
    float chaseSpeed = 5f;
    float patrolWaitTime = 3f;
    float patrolTimer;
    float chaseTimer;
    int wayPointIndex;

    TextMesh seeYouTextMesh;

    Renderer m_renderer;
    Color attackColor = new Color(1, 0, 0);
    bool isAttacking;
    bool isPatrolling;

    float fireRate = 3.0f;
    float nextFire;

    RsPlayerHealth playerHealth;
    RsPlayerManager playerManager = null;


    void Awake()
    {

        /*
        if (RsPlayerManager.m_instance == null)
        {
            Instantiate(playerManager);
        }*/

        agent = GetComponent<NavMeshAgent>();
        m_renderer = GetComponent<Renderer>();
        playerHealth = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<RsPlayerHealth>();
        playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<RsPlayerManager>();
        //        playerHealth = RsPlayerManager.m_instance.playerHealth;

        seeYouText.SetActive(false);
        isAttacking = false;
        isPatrolling = false;

        seeYouTextMesh = seeYouText.GetComponent<TextMesh>();

        if (target == null)
            target = GameObject.FindGameObjectWithTag("Player").transform;

    }

    public void FireHommingRocket()
    {
        if (Time.time > nextFire)
        {
            Vector3 targetDir = target.position - transform.position;
            Vector3 forward = transform.forward;
            float angle = Vector3.Angle(targetDir, forward);
            float dist = Vector3.Distance(target.position, transform.position);

            nextFire = Time.time + fireRate;

            //if (sightingDeltaPos.sqrMagnitude < 80f)
            if ((angle > 1f && angle <= 40f) && (dist > 15f))
            //if ((angle > 1f && angle <= 40f))
            {
                Instantiate(missile, missilePos.position, transform.rotation);
            }
        }
    }

    void Attacking()
    {

        if (playerHealth.IsDeath())
        {
            return;
        }

        agent.speed = 0;

        Vector3 relativePos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 4 * Time.deltaTime);

        FireHommingRocket();
    }

    void Chasing()
    {

        Vector3 sightingDeltaPos = target.position - transform.position;
        if (sightingDeltaPos.sqrMagnitude > 4f)
        {
            agent.destination = target.position;
            agent.speed = chaseSpeed;
        }
    }

    void Patrolling()
    {
        agent.speed = patrolSpeed;

        //if (agent.remainingDistance < agent.stoppingDistance)
        {
            patrolTimer += Time.deltaTime;
            if (patrolTimer >= patrolWaitTime)
            {
                if (wayPointIndex == patrolWayPoints.Length - 1)
                    wayPointIndex = 0;
                else
                    wayPointIndex++;

                patrolTimer = 0;
            }
        }

        if (agent.isActiveAndEnabled)
            agent.destination = patrolWayPoints[wayPointIndex].position;
    }

    void DrawStatusText()
    {
        if (isPatrolling)
        {
        }
        else if (isAttacking)
        {
            seeYouTextMesh.text = "I kill you ! " + m_health.ToString();
            seeYouTextMesh.color = attackColor;
        }
    }

    void Update()
    {
        isAttacking = false;
        isPatrolling = false;

        if (playerHealth.IsDeath())
        {
            isAttacking = false;
            seeYouText.SetActive(false);
            isPatrolling = true;
            Patrolling();
            return;
        }

        Vector3 sightingDeltaPos = target.position - transform.position;
        Vector3 dir = (transform.position - target.position).normalized;

        if (dir.z <= 0f)
        {
            gameObject.SetActive(false);
            return;
        }

        if (sightingDeltaPos.sqrMagnitude > 150f && sightingDeltaPos.sqrMagnitude < 1100f)
        {
            seeYouText.SetActive(true);
            m_renderer.material.color = attackColor;

            isAttacking = true;
            Attacking();
        }
        else
        {
            isAttacking = false;
            seeYouText.SetActive(false);

            isPatrolling = true;
            Patrolling();
        }

        DrawStatusText();
    }

    protected override void OnDeath()
    {
        base.OnDeath();

        playerManager.AddScore(50f);

        // TODO: add sound, effects, etc.
        Destroy(gameObject);
    }

    protected override void OnDamage(float damage)
    {
        base.OnDamage(damage);
        // TODO: add sound, effects, etc.
    }

}
