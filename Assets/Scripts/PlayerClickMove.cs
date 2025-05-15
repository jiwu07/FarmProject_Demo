using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerClickMove : MonoBehaviour
{
    [SerializeField]private UnityEngine.AI.NavMeshAgent playerAgent;

    private Vector3 targetPosition;
    private Animator animator;

    private bool isMoving = false;

    private Camera mainCam;
    private GameControl inputActions;
    private InteractableObject currentTarget;
    [SerializeField]private GameObject currentPlayer;

    void Awake()
    {
        mainCam = Camera.main;
        InputManager.Click += HandleClick;
        animator = currentPlayer.transform.GetChild(0).GetComponent<Animator>(); 
    }

    private void Update()
    {
        if (!playerAgent.pathPending && playerAgent.remainingDistance <= playerAgent.stoppingDistance)
        {
            if (currentTarget != null)
            {
                currentTarget.OnInteract();
                currentTarget = null;
            }
        }
    }

    void HandleClick(Vector2 screenPos)
    {
        Ray ray = mainCam.ScreenPointToRay(screenPos);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.CompareTag(Tag.INTERACTABLE))
            {
                currentTarget = hit.collider.GetComponent<InteractableObject>();
                playerAgent.stoppingDistance = currentTarget.interactionRange;
                playerAgent.SetDestination(currentTarget.transform.position);
            }
            else if (hit.collider.CompareTag(Tag.GROUND))
            {
                currentTarget = null;
                playerAgent.stoppingDistance = 0;
                playerAgent.SetDestination(hit.point);
            }
        }
    }

    
}