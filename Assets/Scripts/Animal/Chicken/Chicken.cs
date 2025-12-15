using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChickenAI : MonoBehaviour
{
    private enum AnimalState
    {
        Idle,
        Moving,
        ReturningToNest
    }
    Vector2 moveDirection;

   SpriteRenderer chickenSP;
    public Animator animator; 

    public float moveSpeed = 3f;
    public float idleTime = 2f;
    public float returnToNestDistance = 1f;

    private Vector2 nestPosition;
    private AnimalState currentState;
    private float idleTimer = 0f;
    private Vector2 randomPosition;

    void Start()
    {
        chickenSP = GetComponent<SpriteRenderer>();
        nestPosition = transform.position;
        SetState(AnimalState.Idle);
    }

    void Update()
    {
        if (moveDirection.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // FlipX
        }
        // Reset sprite orientation if moving right
        else if (moveDirection.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Reset
        }


        switch (currentState)
        {
            case AnimalState.Idle:
                animator.Play("idle");
                idleTimer += Time.deltaTime;
                if (idleTimer >= idleTime)
                {
                    if (Random.value < 0.5f)
                    {
                        SetState(AnimalState.Moving);
                    }
                    else
                    {
                        SetState(AnimalState.ReturningToNest);
                    }
                }
                break;
            case AnimalState.Moving:
                animator.Play("walk");
                MoveToRandomPosition();
                break;
            case AnimalState.ReturningToNest:
                animator.Play("walk");
                MoveToNest();
                break;
        }
    }
    
    void MoveToRandomPosition()
    {
         moveDirection = (randomPosition - (Vector2)transform.position).normalized;
        transform.position = (Vector2)transform.position + moveDirection * moveSpeed * Time.deltaTime;

        if (Vector2.Distance(transform.position, randomPosition) < 0.1f)
        {
            SetState(AnimalState.Idle);
        }
    }
    
    void MoveToNest()
    {
        Vector2 moveDirection = (nestPosition - (Vector2)transform.position).normalized;
        transform.position = (Vector2)transform.position + moveDirection * moveSpeed * Time.deltaTime;

        if (Vector2.Distance(transform.position, nestPosition) <= returnToNestDistance)
        {
            SetState(AnimalState.Idle);
        }
    }

    void SetState(AnimalState newState)
    {
        currentState = newState;
        switch (newState)
        {
            case AnimalState.Idle:
                idleTimer = 0f;
                break;
            case AnimalState.Moving:
                SetRandomPosition();
                break;
            case AnimalState.ReturningToNest:
                break;
        }
    }

    void SetRandomPosition()
    {
        randomPosition = nestPosition + new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
    }
}


