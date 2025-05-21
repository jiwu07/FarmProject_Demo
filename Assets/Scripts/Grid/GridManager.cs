using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;
    private Transform placePosition = null;

    [SerializeField] private Material normalMaterial;
    [SerializeField] private Material selectedMaterial;
    private MeshRenderer[,] mapRender;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return; 
        }
        Instance = this;
        InitialMap();

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
        if (position.childCount == 0)
        {
            InventoryUI.Instance.SetCurrentGrid(null); ;
        }
        else
        {
            //Debug.Log("setplaced position function " + position.gameObject.name);
            InventoryUI.Instance.SetCurrentGrid(position.GetChild(0).GetComponent<GroundGrid>().GetGridSO());

        }
        placePosition = position;
    }

    public Transform GetPlacePosition()
    {
        return placePosition;
    }

    public void InitialMap()
    {
        int width = transform.childCount;
        int height = transform.GetChild(0).childCount;

        mapRender = new MeshRenderer[width, height];
        for (int x = 0; x < width; x++)
        {
            Transform row = transform.GetChild(x);
            for (int i = 0; i < height; i++)
            {
                mapRender[x, i] = row.GetChild(i).gameObject.GetComponent<MeshRenderer>();
                mapRender[x, i].enabled = false;
            }
        }
    }
    
    
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
        //Debug.Log("create ground");
        GameObject go =Instantiate(gridSO.Prefab,placePosition.transform);
        
        //UnSelectPlace(placePosition.gameObject);
    }

    public void ConfirmPlace( GridSO gridSO)
    {
        InventoryUI.Instance.ConfirmPlace(gridSO);
    }
    
    /// <summary>
    /// show the grid mesh
    /// </summary>
    public  void TurnGridOn()
    {
        foreach (MeshRenderer mesh in mapRender)
        {
            if (mesh.GetComponent<GridCell>().IsOccupied()) continue; 
            mesh.enabled = true;
        }
    }
    
    public void TurnGridOFF()
    {
        foreach (MeshRenderer mesh in mapRender)
        {
            mesh.enabled = false;
        }
    }
    
    
}
