using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;
    private Transform placePosition = null;

    [SerializeField] private Material normalMaterial;
    [SerializeField] private Material selectedMaterial;
    //private GridCell[,] map;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return; 
        }
        Instance = this;
        
    }

    public void SelectPlace(GameObject place)
    {
        UnSelectPlace();
        place.GetComponent<Renderer>().material = selectedMaterial;
        SetPlacedPosition(place.transform);
    }
    public void UnSelectPlace()
    {
        if (!placePosition) return;
        placePosition.GetComponent<Renderer>().material = normalMaterial;
    }
    public void SetPlacedPosition(Transform position)
    {
        placePosition = position;
    }

    /*public void InitialMap()
    {
        int width = transform.childCount;
        int height = transform.GetChild(0).childCount;

        map = new GridCell[width, height];
        for (int x = 0; x < width; x++)
        {
            Transform row = transform.GetChild(x);
            for (int i = 0; i < height; i++)
            {
                map[x, i] = row.GetChild(i).gameObject.GetComponent<GridCell>() ;
            }
        }
    }
    */
    
    /// <summary>
    /// generate grid put under this grid
    /// </summary>
    /// <param name="gridSO">placed grid</param>
    public void Place( GridSO gridSO)
    {
        GridCell gc = placePosition.GetComponent<GridCell>();
        if (placePosition == null || gc.IsOccupied())
        {
            return;
        }
        gc.SetCurrentSO(gridSO);
        gc.SetIsOccupied(true);
        //remove the old grid under the place
        if(placePosition.transform.childCount != 0) Destroy(placePosition.transform.GetChild(0));
        //put new grid
        GameObject go =Instantiate(gridSO.Prefab, placePosition.position, Quaternion.identity);
        go.transform.SetParent(placePosition);
        
        //UnSelectPlace(placePosition.gameObject);
    }

    public void ConfirmPlace( GridSO gridSO)
    {
        InventoryUI.Instance.ConfirmPlace(gridSO);
    }
    
}
