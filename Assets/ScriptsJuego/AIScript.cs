using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIScript : MonoBehaviour
{
    Animator m_Animator;
    //patrolling randomly between waypoints
    public Transform[] moveSpots;
    private int randomSpot;


    NavMeshAgent nav;

    //AI Strafe
    public float distToPlayer = 5.0f;

    private float randomStrafeStartTime;
    private float waitStrafeTime;
    public float t_minStrafe;
    public float t_maxStrafe;

    public Transform strafeRight;
    public Transform strafeLeft;
    private int randomStrafeDir;

    //when to chase
    public float chaseRadius = 20f;

    public float facePlayerFactor = 20f;

    //wait time
    private float waitTime;
    public float startWaitTime = 1f;

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.enabled = true;

    }

    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
    }


    void Update()
    {
        float distance = Vector3.Distance(Ballthrow.playerPos, transform.position);

        if (distance > chaseRadius)
        {
            Patrol();
        }
        else if (distance <= chaseRadius)
        {
            ChasePlayer();

            FacePlayer();
        }

    }

        void Patrol()
        {
            nav.SetDestination(moveSpots[randomSpot].position);

            if (Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 2.0f)
            {
                if (waitTime <= 0)
                {
                    randomSpot = Random.Range(0, moveSpots.Length);

                    waitTime = startWaitTime;
                }
                else { waitTime -= Time.deltaTime; }
            }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Armanoletal")
        {
            m_Animator.SetTrigger("Stun");
        }
    }

    void ChasePlayer()
    {

        float distance = Vector3.Distance(Ballthrow.playerPos, transform.position);

        if (distance <= chaseRadius && distance > distToPlayer)
        {
            nav.SetDestination(Ballthrow.playerPos);
        }

        else if (nav.isActiveAndEnabled && distance <= distToPlayer)
        {
            randomStrafeDir = Random.Range(0, 2);
            randomStrafeStartTime = Random.Range(t_minStrafe, t_maxStrafe);

            if (waitStrafeTime <= 0)
            {



                if (randomStrafeDir == 0)
                {
                    nav.SetDestination(strafeLeft.position);

                }

                else
                if (randomStrafeDir == 1)
                {
                    nav.SetDestination(strafeRight.position);

                }
                waitStrafeTime = randomStrafeStartTime;
            }
            else
            {
                waitStrafeTime -= Time.deltaTime;
            }
        }
    }

        void FacePlayer()
        {
            Vector3 direction = (Ballthrow.playerPos - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * facePlayerFactor);
        }



 }



