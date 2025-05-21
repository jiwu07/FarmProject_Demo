using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroundGrid : GridBase
{
    [SerializeField] private Transform plantHolder;
    [SerializeField] private GameObject interactButton;
    [SerializeField] private MeshRenderer groundRenderer;
    [SerializeField] private Image progressBar;
    
    private PlanetStatus currentPlanetStatus;

    private GameObject planetCurrent;
    private Dictionary<PlanetStatus, GameObject> prefabDict;
    private GameObject progressBarObject;

    private PlanetSO planetSO;
    private GridSO gridSO;
    private float waitTime = 2f;
    private float timer = 0;
    //will show, water,take, (clean the ground maybe). planet action is in the click directly
    private bool isWater;
    private bool isPlanted;
    private bool isClearGround = false;
    
    //see if player moving to the tile already
    //private bool isInteractable = true;

    private void Awake()
    {
        prefabDict = new Dictionary<PlanetStatus, GameObject>();
        progressBar.fillAmount = 0f;
        progressBarObject = progressBar.transform.parent.gameObject;
        progressBarObject.SetActive(false);
        
    }

    public GridSO GetGridSO()
    {
        return gridSO;
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

    private void SetProgressBar()
    {
        if(!progressBarObject.activeSelf) progressBarObject.SetActive(true);
        progressBar.fillAmount = timer/waitTime;
    }

    public override void Interact(UnityEngine.AI.NavMeshAgent playerAgent)
    {
        //if (!isInteractable) return;
        // open bag show planetList or directly shop, but directly, no inventory system
        //if in the place mode,click the ground put back in bag, which means nothing happen here
        if (PlaceModeManager.instance.IsPlaceModeOn()) return;

        //here normal interaction depends on the situation of the ground
        if (!isPlanted)
        {
            //if empty then open the shop and buy and planet the seed
            ShopUI.Instance.OpenShop();
            return;
        }
        
        //isplaneted, then check if need water
        if (!isWater)
        {
            //need to be water, check the timer
            if (currentPlanetStatus == PlanetStatus.Half)
            {
             //planet till water step, so need to be water 
             if (!Player.Instance.SkillExists(SkillType.Water)) return;
             Water();
             return;
            }
            //else just wait till it can be water
            return;
        }

        //is water and planet status is grown and ready to take
        if (currentPlanetStatus == PlanetStatus.Grown)
        {
            //todo, take the planet sold as money directly
            //Harvest();
            if (!Player.Instance.SkillExists(SkillType.Harvest)) return;
            isClearGround = true;

        }
        
        //else just wait
        
    }

    private void Timer()
    {
        if (!planetSO || currentPlanetStatus.Equals(PlanetStatus.Grown)) return;
        if (isPlanted && !isWater)
        {
            //Debug.Log("isplanet" + isPlanted + "timer start");
            if (timer < waitTime && currentPlanetStatus.Equals(PlanetStatus.Seed))
            {
                SetProgressBar();
                timer += Time.deltaTime;
                //Debug.Log(timer + "wait for walter");
            }
            else
            {
                currentPlanetStatus = PlanetStatus.Half;
                interactButton.SetActive(true);
                progressBarObject.SetActive(false);
                timer = 0;
            }

        }

        if (isWater && isPlanted)
        {
            if (timer < waitTime && currentPlanetStatus.Equals(PlanetStatus.Half))
            {
                SetProgressBar();
                timer += Time.deltaTime;
                //Debug.Log(timer + "wait for grow");
            }
            else
            {
                currentPlanetStatus = PlanetStatus.Grown;
                Grown();
                interactButton.SetActive(true);
                timer = 0;
                progressBarObject.SetActive(false);

            }
        }
        
       
    }

    private void Update()
    {
        if (isPlanted && !currentPlanetStatus.Equals(PlanetStatus.Grown))
        {
            Timer();
        }
        
        if (isClearGround)
        {
            if (timer < waitTime)
            {
                SetProgressBar();
                timer += Time.deltaTime;
            }
            else
            {
                Harvest();
                timer = 0;
                progressBarObject.SetActive(false);
            }
        }
    }

    public void Planet(PlanetSO planetSO)
    {
        if(!planetSO) return;
        
        init(planetSO);
        planetCurrent = Instantiate(prefabDict[PlanetStatus.Seed], this.transform);
        //inactive the ground mesh the previous object
        currentPlanetStatus = PlanetStatus.Seed;
        groundRenderer.enabled = false;
        planetCurrent.transform.SetParent(plantHolder);
        interactButton.SetActive(false);

    }

    public void Water()
    {

        
        //Debug.Log("try to water"); todo somehow not playing
        Player.Instance.GetPlayerAnimation().Water();
       
        //Debug.Log(" watering ");
        //remove the old prefab and put new
        ClearPlanet();
        planetCurrent = Instantiate(prefabDict[PlanetStatus.Half], this.transform);
        //inactive the ground mesh the previous object
        planetCurrent.transform.SetParent(plantHolder);
        isWater = true;
        interactButton.SetActive(false);
    }

    private void Grown()
    {
        ClearPlanet();
        planetCurrent = Instantiate(prefabDict[PlanetStatus.Grown], this.transform);
        planetCurrent.transform.SetParent(plantHolder);
    }

    public void Harvest()
    {
        
        //animation
        Player.Instance.GetPlayerAnimation().Harvest();
        //todo,here need to be optimized
        //Animator planetAnimator = planetCurrent.transform.GetChild(0).GetComponent<Animator>();
       // if(!planetAnimator) planetAnimator.SetTrigger("Taken");
       
        //coin system
        CoinManager.Instance.AddCoin(planetSO.earn);
       
        isPlanted = false;
        isWater = false;
        ClearPlanet();
        groundRenderer.enabled = true;
        planetCurrent = null;
        planetSO = null;
        prefabDict.Clear();
        interactButton.SetActive(false);
        
        
    }

    private void ClearPlanet()
    {
        Destroy(plantHolder.GetChild(0).gameObject);
        isClearGround = false;
    }

 
}