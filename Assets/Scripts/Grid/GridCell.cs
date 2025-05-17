using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    public float interactionRange = 1.5f;

     
    private bool isOccupied = false;
    private GameObject currentCell = null;



    public bool IsOccupied()
    {
        return isOccupied;
    }
    
    public bool IsEmpty()
    {
        return !isOccupied;
    }

    //logic of interact. like planet stuff etc
    public void Interact(UnityEngine.AI.NavMeshAgent playerAgent)
    {
        Debug.Log("Interact grid cell");
        //grid empty and not in place mode
        if (!isOccupied && !PlaceModeManager.instance.IsPlaceModeOn()) return;
        
        //empty but in place mode
        if (!isOccupied && PlaceModeManager.instance.IsPlaceModeOn())
        {
            //open bag to put stuff like ground etc
            Debug.Log("Place mode On and free grid cell");
            InventoryUI.Instance.OpenInventory();
            GridManager.Instance.SetPlacedPosition(transform);
            return;
        }
        
        //not empty and in place mode
        if (isOccupied && PlaceModeManager.instance.IsPlaceModeOn())
        {
            //take the placed prefab away back in bag
            Debug.Log(gameObject.name + " is not empty and put the stuff to bag ");
            //todo
            //empty the grid
            Destroy(transform.GetChild(0));
            isOccupied = false;
            //put the SO to bag
            
        }
        
        //not empty and not in place mode
        if (isOccupied && !PlaceModeManager.instance.IsPlaceModeOn())
        {
            //go to the placed prefab  anf interact
            currentCell.GetComponent<GridCell>().Interact(playerAgent);
            
        }
        
        
    }
}
