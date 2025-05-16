using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerClickMove : MonoBehaviour
{
    [SerializeField]private UnityEngine.AI.NavMeshAgent playerAgent;

    private Vector3 targetPosition;
    private Camera mainCam;
    private GameControl inputActions;
    private InteractableObject currentTarget;
    

    void Start()
    {
        mainCam = Camera.main;
        InputManager.ClickMove += HandleClickMove;
    }


    void HandleClickMove(Vector2 screenPos)
    {
        //move
        Ray ray = mainCam.ScreenPointToRay(screenPos);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.CompareTag(Tag.INTERACTABLE))
            {
                hit.collider.GetComponent<InteractableObject>().OnClick(playerAgent);
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