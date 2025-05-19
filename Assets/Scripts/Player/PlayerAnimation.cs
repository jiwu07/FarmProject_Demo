using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimation : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;

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
            //Debug.Log("water animation section in playanimation");
            animator = GetComponent<Animator>();
        }
        Debug.Log(animator + "Harvest");
        animator.SetTrigger(AnimationParams.Harvest);
    }

    public void Water()
    {
        //Debug.Log("water animation section in playanimation");
        if (!animator)
        {
            //Debug.Log("water animation section in playanimation");
            animator = GetComponent<Animator>();
        }
        Debug.Log("play animation water " + animator.name);
        animator.SetTrigger(AnimationParams.Water);
  
    }
}
