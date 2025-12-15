using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcAI : MonoBehaviour
{
    [SerializeField] public Transform target;
    NavMeshAgent agent;
    private Animator animator;
    public float stoppingDistance = 0.6f;

    public bool canMove = true;
    float startSpeedMove;
    public bool backHome;
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        startSpeedMove = agent.speed;


    }


    public float time; 
    // Update is called once per frame
    void Update()
    {
       time = time + Time.deltaTime;
        if (!backHome)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponentInChildren<BoxCollider2D>().enabled = true;
        } 
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        Vector2 movement = agent.velocity.normalized;

        if (movement.magnitude > 0)
        {
            animator.SetBool("Running", true);
        }
        else
        {
            animator.SetBool("Running", false);
        }
       if(distanceToTarget > stoppingDistance) 
        {
            if (canMove)
            {
                agent.SetDestination(target.position);
                animator.SetFloat("inputX", movement.x);
                animator.SetFloat("inputY", movement.y);
            }

            if (canMove == false)
            {
                agent.speed = 0;
            }
            else
            {
               
                agent.speed = startSpeedMove;
            }
        }

        if (distanceToTarget <= stoppingDistance)
        {
            if (backHome)
            {
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponentInChildren<BoxCollider2D>().enabled = false;
            }
        }
    }
}
