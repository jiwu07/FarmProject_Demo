using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
   [SerializeField]private PlanetSO planetSo;
   [SerializeField]private Image icon;

   public void InitShopItem(PlanetSO planetSo)
   {
      
      this.planetSo = planetSo;
      this.icon.sprite = planetSo.seedSprite;
      
   }
   public void ShowDetail()
   {
      //show character details 
      ShopUI.Instance.ShowItemDetail(planetSo);
   }
   
}
