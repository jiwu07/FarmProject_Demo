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
    private float interactionRange = 1f;
    

    void Start()
    {
        mainCam = Camera.main;
        InputManager.ClickMove += HandleClickMove;
        playerAgent.stoppingDistance = interactionRange;
    }


    void HandleClickMove(Vector2 screenPos)
    {
       //Debug.Log("HandleClickMove");
        //move
        Ray ray = mainCam.ScreenPointToRay(screenPos);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.CompareTag(Tag.INTERACTABLE))
            {
                hit.collider.GetComponent<GridCell>().Interact(playerAgent);
                
            }
            else if (hit.collider.CompareTag(Tag.GROUND) && !PlaceModeManager.instance.IsPlaceModeOn())
            {
                //close all ui
                CharacterUI.Instance.Hide();
                InventoryUI.Instance.Hide();
                ShopUI.Instance.CloseShop();
                
                
                playerAgent.SetDestination(hit.point);
                return;
            }else if (hit.collider.CompareTag(Tag.DECORATION) && !PlaceModeManager.instance.IsPlaceModeOn())
            {
                hit.collider.GetComponent<DecorationGrid>().Interact(playerAgent);
            }else if (hit.collider.CompareTag(Tag.TASK))
            {
                hit.collider.GetComponent<TaskManager>().Interact(playerAgent);
            }
            playerAgent.SetDestination(hit.point);

            /*if (!PlaceModeManager.instance.IsPlaceModeOn())
            {
                playerAgent.SetDestination(hit.point);
            }*/
        }
    }

    
}