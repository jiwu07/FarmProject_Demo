using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    public static ShopUI Instance;
    [SerializeField] private GameObject shop;
    [SerializeField] private GameObject shopItemPrefab;
    [SerializeField] private GameObject detail;
    [SerializeField] private Transform content;
    [SerializeField] private List<PlanetSO> itemsList;

    private ItemDetail itemDetail;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        
        itemDetail = detail.GetComponent<ItemDetail>();
    }

    private void UpdateShop()
    {
        //remove old item
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }
        //refresh items
        foreach (var item in itemsList)
        {
            GameObject go = Instantiate(shopItemPrefab, content.transform);
            go.transform.SetParent(content);
            go.GetComponent<ShopItem>().InitShopItem(item);
            
        }
    }

    public void OpenShop()
    {
        if (shop.activeSelf)
        {
            shop.SetActive(false);
            return;
        }
        UpdateShop();
        shop.SetActive(true);
        
    }

    public void ShowItemDetail(PlanetSO planet)
    {
        //Debug.Log(" detail shop+ " + itemDetail);
        itemDetail.ShowDetail(planet);
        
    }

    public void CloseShop()
    {
        shop.SetActive(false);
    }
}
