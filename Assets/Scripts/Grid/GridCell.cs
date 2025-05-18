using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;
using Debug = System.Diagnostics.Debug;

public class GridCell : MonoBehaviour
{
    public float interactionRange = 1.5f;

     
    private bool isOccupied = false;
    private GameObject currentCell = null;
    private GridSO currentSO;

    public bool IsOccupied()
    {
        return isOccupied;
    }

    public void SetCurrentSO(GridSO gridSO)
    {
        currentSO = gridSO;
    }

    public void SetIsOccupied(bool isOccupied)
    {
        this.isOccupied = isOccupied;
    }
    
    
    public bool IsEmpty()
    {
        return !isOccupied;
    }

    //logic of interact. like planet stuff etc
    public void Interact(UnityEngine.AI.NavMeshAgent playerAgent)
    {
        //shown the selecte place
        GridManager.Instance.SelectPlace(this.gameObject);
        
        //grid empty and not in place mode
        if (!isOccupied && !PlaceModeManager.instance.IsPlaceModeOn()) return;
        
        //empty but in place mode
        if (!isOccupied && PlaceModeManager.instance.IsPlaceModeOn())
        {
            //open bag to put stuff like ground etc
            InventoryUI.Instance.OpenInventory();
            return;
        }

        InventoryUI.Instance.SetCurrentGrid(currentSO);
        //not empty and in place mode
        if (isOccupied && PlaceModeManager.instance.IsPlaceModeOn())
        {
            //UnityEngine.Debug.Log("此处应该吧土地收回去");            
            //take the placed prefab away back in bag
            //put in bag
            InventoryUI.Instance.PutItem(currentSO);
            //empty the go under the grid
            Destroy(transform.GetChild(0).gameObject);
            isOccupied = false;
     
        }
        
        //not empty and not in place mode
        if (isOccupied && !PlaceModeManager.instance.IsPlaceModeOn())
        {
            //go to the placed prefab  anf interact
            transform.GetChild(0).GetComponent<GridBase>().Interact(playerAgent);
        }
        
        
    }
}
