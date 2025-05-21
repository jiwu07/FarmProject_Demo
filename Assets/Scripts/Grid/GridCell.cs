using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    //public float interactionRange = 1.5f;

     
    [SerializeField]private bool isOccupied = false;
    [SerializeField]private GameObject currentCell = null;
    [SerializeField]private GridSO currentSO = null;

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
            //take the placed prefab away back in bag
            //put in bag
            InventoryUI.Instance.PutItem(currentSO);
            currentSO = null;
            currentCell = null;
            //empty the go under the grid
            Destroy(transform.GetChild(0).gameObject);
            isOccupied = false;
        }
        
        //not empty and not in place mode
        if (isOccupied && !PlaceModeManager.instance.IsPlaceModeOn())
        {
            Debug.Log("Interact  to interact with ground");
            //go to the placed prefab  anf interact
            transform.GetChild(0).GetComponent<GridBase>().Interact(playerAgent);
        }
        
        
    }
}
