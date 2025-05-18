using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGrid : GridBase
{
    [SerializeField] private Transform plantHolder;
    private GameObject planetCurrent;
    private PlanetSO planetSO;
    private GridSO gridSO;
    private int Timer;
    //will show, water,take, (clean the ground maybe). planet action is in the click directly
    private GameObject interactButton;
    private bool isWater;
    private bool isFinished;
    
    //see if player moving to the tile already
    private bool isInteractable = true;
    public override void Interact(UnityEngine.AI.NavMeshAgent playerAgent)
    {
        if (!isInteractable) return;
        Debug.Log($"{name} InteractGround 土地 被交互了！");
        // open bag show planetList or directly shop, but directly, no inventory system
        if (PlaceModeManager.instance.IsPlaceModeOn())
        {
            //if in the place mode,click the ground put back in bag
            
        }
        //InventoryUI.Instance.OpenInventory();
    }


}