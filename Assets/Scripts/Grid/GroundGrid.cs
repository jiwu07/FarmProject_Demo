using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGrid : GridBase
{
    [SerializeField] private Transform plantHolder;
    [SerializeField] private GameObject interactButton;
    [SerializeField] private MeshRenderer groundRenderer;

    private GameObject planetCurrent;
    private Dictionary<PlanetStatus, GameObject> prefabDict;

    private PlanetSO planetSO;
    private GridSO gridSO;
    private float waitTime = 20f;
    private float timer;
    //will show, water,take, (clean the ground maybe). planet action is in the click directly
    private bool isWater;
    private bool isPlanted;
    
    //see if player moving to the tile already
    private bool isInteractable = true;

    private void Awake()
    {
        prefabDict = new Dictionary<PlanetStatus, GameObject>();

        
    }

    public void init(PlanetSO planetSo)
    {
        this.planetSO = planetSo;
        foreach (var item in planetSO.statusPrefabs)
        {
            if (!prefabDict.ContainsKey(item.status))
            {
                prefabDict.Add(item.status, item.preFab);
            }
            
        }

        isWater = false;
        isPlanted = true;
    }

    public override void Interact(UnityEngine.AI.NavMeshAgent playerAgent)
    {
        Debug.Log("interactwith ground");
        if (!isInteractable) return;
        // open bag show planetList or directly shop, but directly, no inventory system
        //if in the place mode,click the ground put back in bag, which means nothing happen here
        if (PlaceModeManager.instance.IsPlaceModeOn()) return;

        //here normal interaction depends on the situation of the ground
        if (!isPlanted)
        {
            //if empty then open the shop and buy and planet the seed
            Debug.Log("open shop to buy seed and planet");
            ShopUI.Instance.OpenShop();
            return;
        }
        
        //isplaneted, then check if need water
        if (!isWater)
        {
            //need to be water, check the timer
            if (planetSO.statusCurrent == PlanetStatus.Half)
            {
             //planet till water step, so need to be water  
             //todo water
             isWater = true;
             return;
            }
            //else just wait till it can be water
            return;
        }

        //is water and planet status is grown and ready to take
        if (planetSO.statusCurrent == PlanetStatus.Grown)
        {
            //todo, take the planet sold as money directly
        }
        
        //else just wait
        
    }

    private void Timer()
    {
        if (!planetSO || planetSO.statusCurrent.Equals(PlanetStatus.Grown)) return;
        if (isPlanted && !isWater)
        {
            if (timer < waitTime && planetSO.statusCurrent.Equals(PlanetStatus.Seed))
            {
                timer += Time.deltaTime;
            }
            else
            {
                planetSO.statusCurrent = PlanetStatus.Half;
                interactButton.SetActive(true);
                timer = 0;
            }

        }

        if (isWater && isPlanted)
        {
            if (timer < waitTime && planetSO.statusCurrent.Equals(PlanetStatus.Half))
            {
                timer += Time.deltaTime;
            }
            else
            {
                planetSO.statusCurrent = PlanetStatus.Grown;
                Grown();
                interactButton.SetActive(true);
                timer = 0;
            }
        }
    }

    private void Update()
    {
        if (isPlanted)
        {
            Timer();
        }
    }

    public void Planet(PlanetSO planetSO)
    {
        if(!planetSO) return;
        
        init(planetSO);
        planetCurrent = Instantiate(prefabDict[PlanetStatus.Seed], this.transform);
        //inactive the ground mesh the previous object
        groundRenderer.enabled = false;
        planetCurrent.transform.SetParent(plantHolder);
        interactButton.SetActive(false);

    }

    public void Water()
    {
        planetCurrent = Instantiate(prefabDict[PlanetStatus.Half], this.transform);
        //inactive the ground mesh the previous object
        planetCurrent.transform.SetParent(plantHolder);
        isWater = true;
        interactButton.SetActive(false);
    }

    private void Grown()
    {
        planetCurrent = Instantiate(prefabDict[PlanetStatus.Grown], this.transform);
        planetCurrent.transform.SetParent(plantHolder);
    }

    public void Taken()
    {
        isPlanted = false;
        isWater = false;
        groundRenderer.enabled = true;
        Destroy(plantHolder.GetChild(0).gameObject);
        planetCurrent = null;
        planetSO = null;
        prefabDict.Clear();
        interactButton.SetActive(false);

    }
}