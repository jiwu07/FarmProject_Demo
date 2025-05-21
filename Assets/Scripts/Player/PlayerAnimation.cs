using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimation : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;

    private bool water = false;

    public void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GameObject.Find("Player").GetComponent<NavMeshAgent>();
    }
    void Update()
    {
       Walking();
       
       
    }

    void Walking()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
            {
                animator.SetBool(AnimationParams.IsWalking, false);
            }
        }
        else
        {
            animator.SetBool(AnimationParams.IsWalking, true);
        }

    }

    void Clean()
    {
        animator.SetTrigger(AnimationParams.Clean);
    }
    
    public void Harvest()
    {
        if (!animator)
        {
            animator = GetComponent<Animator>();
        }
        Debug.Log( "Harvest animation should be played");
        animator.SetTrigger(AnimationParams.Harvest);
    }

    public void Water()
    {
        water = true;
        if (!animator)
        {
            animator = GetComponent<Animator>();
        }
        animator.SetTrigger(AnimationParams.Water);
        Debug.Log("Water animation should be played but somehow not");
  
    }
}
