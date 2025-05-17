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
    private GridCell currentTarget;
    

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
                hit.collider.GetComponent<GridCell>().Interact(playerAgent);
                currentTarget = hit.collider.GetComponent<GridCell>();
                if (!PlaceModeManager.instance.IsPlaceModeOn())
                {
                    playerAgent.stoppingDistance = currentTarget.interactionRange;
                    playerAgent.SetDestination(currentTarget.transform.position);
                }

            }
            else if (hit.collider.CompareTag(Tag.GROUND) && !PlaceModeManager.instance.IsPlaceModeOn())
            {
                currentTarget = null;
                playerAgent.stoppingDistance = 0;
                playerAgent.SetDestination(hit.point);
            }
        }
    }

    
}