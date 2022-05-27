using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatMovementAnimator : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent navMeshAgent;
    Animator animator;
    void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();

    }
    
    void Update()
    {
        animator.SetFloat("Speed", navMeshAgent.velocity.magnitude);   
    }
}