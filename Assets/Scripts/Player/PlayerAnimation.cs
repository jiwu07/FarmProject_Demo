using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]private NavMeshAgent agent;
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
       Walking();
    }

    void Walking()
    {
        if (agent.remainingDistance < 0.1f|| agent.pathPending)
        {
            animator.SetBool("IsWalking", false);
        }
        else
        {
            animator.SetBool("IsWalking",true);
        }
    }

    void Clean()
    {
        animator.SetTrigger("Clean");
    }
    
    void Collect()
    {
        animator.SetTrigger("Collect");
    }
}
