using System;
using UnityEngine;

public class PlaceModeManager : MonoBehaviour
{
    public static PlaceModeManager instance;

    [SerializeField] private GameObject gridManager;
    [SerializeField] private GameObject player;

    private bool isPlaceModeOn ;
    
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return; 
        }
        instance = this;

        isPlaceModeOn = false;
    }
    

    public bool IsPlaceModeOn()
    {
        return isPlaceModeOn;   
    }

    public void ClickPlaceMode()
    {
        isPlaceModeOn = !isPlaceModeOn;
        //make player disappear and turn on mode
        if (!isPlaceModeOn)
        {
            player.transform.GetChild(0).gameObject.SetActive(true);
            GridManager.Instance.UnSelectPlace();
            GridManager.Instance.TurnGridOFF();
            return;
        }
        //InventoryUI.Instance.SetCurrentGrid(null);
        player.transform.GetChild(0).gameObject.SetActive(false);
        GridManager.Instance.TurnGridOn();
        
    }

 

    
    
}