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
      
      //moneysystem 
      if (CoinManager.Instance.GetCurrentCoins() < planetSo.cost)
      {
         NotificationUI.Instance.Show("I don't have this skill ;(");
         return;
      }
      CoinManager.Instance.SubtractCoin(planetSo.cost);
      
      
      //planet it
      GroundGrid gg = currentGround.GetChild(0).GetComponent<GroundGrid>();
      gg.Planet(planetSo);
      HideDetail();
      ShopUI.Instance.CloseShop();
   }
   
   
}
