using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDetail : MonoBehaviour
{
   public PlanetSO planetSo;
   public TextMeshProUGUI itemName;
   public Image icon;



   public void ShowDetail(PlanetSO planet)
   {
      gameObject.SetActive(true);

      planetSo = planet;
      itemName.text = planet.name;
      icon.sprite = planetSo.seedSprite;
   }

   public void HideDetail()
   {
      gameObject.SetActive(false);
   }

   public void BuyItem()
   {
      Transform currentGround = GridManager.Instance.GetPlacePosition();
      if(!currentGround) return;
      //todo
      //moneysystem 
      
      
      //planet it
      GroundGrid gg = currentGround.GetChild(0).GetComponent<GroundGrid>();
      gg.Planet(planetSo);
      HideDetail();
      ShopUI.Instance.CloseShop();
   }
   
   
}
